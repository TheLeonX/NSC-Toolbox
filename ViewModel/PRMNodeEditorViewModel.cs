using NSC_Toolbox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NSC_Toolbox.ViewModel
{
    public class PRMNodeEditorViewModel : INotifyPropertyChanged
    {
        private class RelayCommand : ICommand
        {
            private readonly Action _act;
            public event EventHandler CanExecuteChanged;
            public RelayCommand(Action act) { _act = act; }
            public bool CanExecute(object parameter) => true;
            public void Execute(object parameter) => _act();
        }

        private PRMVER_Model _verModel;
        private string _status;

        public ObservableCollection<NodeViewModel> Nodes { get; } = new ObservableCollection<NodeViewModel>();
        // Разделение слоев ссылок
        public ObservableCollection<LinkViewModel> LinksBehind { get; } = new ObservableCollection<LinkViewModel>();
        public ObservableCollection<LinkViewModel> LinksFront { get; } = new ObservableCollection<LinkViewModel>();

        public string VerName { get; private set; }

        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
        public ICommand AutoLayoutCommand { get; }

        public PRMNodeEditorViewModel()
        {
            SaveCommand = new RelayCommand(SaveBack);
            AutoLayoutCommand = new RelayCommand(() => AutoLayout());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Load(PRMVER_Model ver)
        {
            _verModel = ver ?? throw new ArgumentNullException("ver");
            VerName = ver.BinName ?? "VER";
            OnPropertyChanged(nameof(VerName));
            Nodes.Clear();
            LinksBehind.Clear();
            LinksFront.Clear();

            int num = 0;
            foreach (PRM_PL_ANM_Model item in ver.PL_ANM_Sections ?? new ObservableCollection<PRM_PL_ANM_Model>())
            {
                NodeViewModel node = new NodeViewModel(item)
                {
                    X = 80 + (num % 6) * 260,
                    Y = 40 + (num / 6) * 180
                };
                Nodes.Add(node);
                num++;
            }

            RebuildLinks();
            foreach (var n in Nodes) n.PropertyChanged += Node_PropertyChanged;
            AutoLayout();

            Status = $"Loaded {Nodes.Count} nodes, {LinksFront.Count + LinksBehind.Count} links.";
        }

        private void Node_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NodeViewModel.X) || e.PropertyName == nameof(NodeViewModel.Y))
            {
                RaiseAllLinksPositionChanged();
            }
        }

        /// <summary>
        /// Пересобрать ссылки в зависимости от PrevText/NextText.
        /// Prev-дублируется и в заднем, и в переднем слоях (пользователь хотел behind AND in front).
        /// Next и Current помещаем в передний слой.
        /// </summary>
        public void RebuildLinks()
        {
            LinksBehind.Clear();
            LinksFront.Clear();

            // unique key map: если ключ пустой, юзаем индекс суффиксом
            var map = new Dictionary<string, NodeViewModel>(StringComparer.Ordinal);
            for (int i = 0; i < Nodes.Count; i++)
            {
                var key = Nodes[i].GetKeyString();
                if (string.IsNullOrEmpty(key)) key = $"<unnamed_{i}>";
                // если дубликат — добавляем суффикс
                var original = key;
                int suffix = 1;
                while (map.ContainsKey(key))
                {
                    key = $"{original}_{suffix++}";
                }
                map[key] = Nodes[i];
            }

            // Сохраним PrevText/NextText как есть у NodeViewModel; но для ссылок будем искать соответствие
            // Пополняем коллекции ссылок
            foreach (var node in Nodes)
            {
                if (!string.IsNullOrWhiteSpace(node.PrevText))
                {
                    // prevText может быть key из map; пробуем точное совпадение или по "основному" ключу
                    if (map.TryGetValue(node.PrevText, out var prevNode))
                    {
                        LinksBehind.Add(new LinkViewModel(prevNode, node));
                        LinksFront.Add(new LinkViewModel(prevNode, node)); // дублируем
                        node.IsPrevMissing = false;
                    } else
                    {
                        // попытка искать без суффикса (если пользователь ввёл original key)
                        var found = map.FirstOrDefault(kv => kv.Key.StartsWith(node.PrevText, StringComparison.Ordinal));
                        if (!found.Equals(default(KeyValuePair<string, NodeViewModel>)))
                        {
                            LinksBehind.Add(new LinkViewModel(found.Value, node));
                            LinksFront.Add(new LinkViewModel(found.Value, node));
                            node.IsPrevMissing = false;
                        } else node.IsPrevMissing = true;
                    }
                } else node.IsPrevMissing = true;

                if (!string.IsNullOrWhiteSpace(node.NextText))
                {
                    if (map.TryGetValue(node.NextText, out var nextNode))
                    {
                        LinksFront.Add(new LinkViewModel(node, nextNode));
                        node.IsNextMissing = false;
                    } else
                    {
                        var found = map.FirstOrDefault(kv => kv.Key.StartsWith(node.NextText, StringComparison.Ordinal));
                        if (!found.Equals(default(KeyValuePair<string, NodeViewModel>)))
                        {
                            LinksFront.Add(new LinkViewModel(node, found.Value));
                            node.IsNextMissing = false;
                        } else node.IsNextMissing = true;
                    }
                } else node.IsNextMissing = true;
            }

            RaiseAllLinksPositionChanged();
            Status = $"Rebuilt links: {LinksBehind.Count} behind, {LinksFront.Count} front.";
        }

        /// <summary>
        /// Принудительно обновляет позиции линий.
        /// </summary>
        public void RaiseAllLinksPositionChanged()
        {
            foreach (var l in LinksBehind) l.RaisePositionChanged();
            foreach (var l in LinksFront) l.RaisePositionChanged();
        }

        /// <summary>
        /// Простая авто-раскладка:
        /// - компоненты графа размещаем отдельно
        /// - внутри компоненты используем Next как направление
        /// - если несколько узлов ссылаются на один и тот же узел (incoming >1), их размещаем на отдельной подстроке
        /// </summary>
        private void AutoLayout()
        {
            // подготовка ключ->узел (уникальные ключи)
            var keyToNode = new Dictionary<string, NodeViewModel>(StringComparer.Ordinal);
            for (int i = 0; i < Nodes.Count; i++)
            {
                var k = Nodes[i].GetKeyString();
                if (string.IsNullOrEmpty(k)) k = $"<unnamed_{i}>";
                var baseK = k;
                int suf = 1;
                while (keyToNode.ContainsKey(k))
                {
                    k = $"{baseK}_{suf++}";
                }
                keyToNode[k] = Nodes[i];
            }

            // outgoing по NextText
            var outgoing = Nodes.ToDictionary(n => n, n => new List<NodeViewModel>());
            foreach (var n in Nodes)
            {
                if (!string.IsNullOrWhiteSpace(n.NextText))
                {
                    if (keyToNode.TryGetValue(n.NextText, out var nxt))
                        outgoing[n].Add(nxt);
                    else
                    {
                        var found = keyToNode.FirstOrDefault(kv => kv.Key.StartsWith(n.NextText, StringComparison.Ordinal));
                        if (!found.Equals(default(KeyValuePair<string, NodeViewModel>)))
                            outgoing[n].Add(found.Value);
                    }
                }
            }

            // неориентированная связность для компонентов
            var adj = Nodes.ToDictionary(n => n, n => new List<NodeViewModel>());
            foreach (var n in Nodes)
            {
                foreach (var t in outgoing[n])
                {
                    adj[n].Add(t);
                    adj[t].Add(n);
                }
            }

            var visited = new HashSet<NodeViewModel>();
            var components = new List<List<NodeViewModel>>();
            foreach (var n in Nodes)
            {
                if (visited.Contains(n)) continue;
                var comp = new List<NodeViewModel>();
                var q = new Queue<NodeViewModel>();
                q.Enqueue(n);
                visited.Add(n);
                while (q.Count > 0)
                {
                    var cur = q.Dequeue();
                    comp.Add(cur);
                    foreach (var nb in adj[cur])
                    {
                        if (!visited.Contains(nb))
                        {
                            visited.Add(nb);
                            q.Enqueue(nb);
                        }
                    }
                }
                components.Add(comp);
            }

            int row = 0;
            int startX = 80;
            int spacingX = 320;
            int baseY = 40;
            int spacingY = 120;

            foreach (var comp in components)
            {
                if (comp.Count == 1)
                {
                    var s = comp[0];
                    s.X = startX;
                    s.Y = baseY + row * spacingY;
                    row++;
                    continue;
                }

                // входящие внутри компоненты
                var compSet = new HashSet<NodeViewModel>(comp);
                var inLocal = comp.ToDictionary(n => n, n => 0);
                foreach (var n in comp)
                    foreach (var t in outgoing[n])
                        if (compSet.Contains(t)) inLocal[t]++;

                // корни внутри компоненты
                var roots = comp.Where(n => inLocal[n] == 0).ToList();
                var used = new HashSet<NodeViewModel>();
                var paths = new List<List<NodeViewModel>>();

                if (roots.Count == 0)
                {
                    // цикл: строим простые пути начиная с каждого узла пока не встретится повтор
                    foreach (var st in comp)
                    {
                        if (used.Contains(st)) continue;
                        var cur = st;
                        var local = new HashSet<NodeViewModel>();
                        var path = new List<NodeViewModel>();
                        while (cur != null && !local.Contains(cur))
                        {
                            local.Add(cur);
                            path.Add(cur);
                            used.Add(cur);
                            var next = outgoing[cur].FirstOrDefault(x => compSet.Contains(x) && !local.Contains(x));
                            if (next == null) break;
                            cur = next;
                        }
                        if (path.Count > 0) paths.Add(path);
                    }
                } else
                {
                    // для каждого корня делаем DFS, ветки становятся разными path'ами
                    foreach (var root in roots)
                    {
                        if (used.Contains(root)) continue;
                        var stack = new Stack<(NodeViewModel node, List<NodeViewModel> path)>();
                        stack.Push((root, new List<NodeViewModel>()));
                        while (stack.Count > 0)
                        {
                            var (cur, path) = stack.Pop();
                            if (used.Contains(cur)) continue;
                            var newPath = new List<NodeViewModel>(path) { cur };
                            used.Add(cur);

                            var outs = outgoing[cur].Where(x => compSet.Contains(x)).ToList();
                            if (outs.Count == 0)
                            {
                                paths.Add(newPath);
                            } else
                            {
                                // если несколько ветвей — пушим каждый в стек (branch => отдельный path)
                                foreach (var o in outs)
                                {
                                    stack.Push((o, newPath));
                                }
                            }
                        }
                    }

                    // оставшиеся узлы не в used — создаём paths
                    foreach (var rem in comp.Where(x => !used.Contains(x)))
                    {
                        var cur = rem;
                        var local = new HashSet<NodeViewModel>();
                        var path = new List<NodeViewModel>();
                        while (cur != null && !local.Contains(cur))
                        {
                            local.Add(cur);
                            path.Add(cur);
                            used.Add(cur);
                            var next = outgoing[cur].FirstOrDefault(x => compSet.Contains(x) && !local.Contains(x));
                            if (next == null) break;
                            cur = next;
                        }
                        if (path.Count > 0) paths.Add(path);
                    }
                }

                // разместить каждуую path как строку: x = depth*spacingX, y = row*spacingY
                foreach (var path in paths)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        path[i].X = startX + i * spacingX;
                        path[i].Y = baseY + row * spacingY;
                    }
                    row++;
                }
            }

            RaiseAllLinksPositionChanged();
            Status = $"Auto layout applied: components {components.Count}, rows {row}.";
        }
        /// <summary>
        /// Увеличивает холст при необходимости — внешний код вызывает EnsureCanvasSize после изменения X/Y.
        /// Здесь просто заглушка: размещение вьюшки делается в code-behind; ViewModel хранит только данные.
        /// (Если нужен доступ к MainCanvas из VM — можно поднять событие.)
        /// </summary>
        public void EnsureCanvasSize(double minWidth, double minHeight)
        {
            // В VM оставляем метод-пустышку для вызова из code-behind.
            // code-behind не использует возвращаемое значение.
        }

        private void SaveBack()
        {
            if (_verModel == null) { Status = "No model loaded."; return; }
            var dict = Nodes.ToDictionary(n => n.GetKeyString(), n => n, StringComparer.Ordinal);
            foreach (var node in Nodes)
            {
                if (!string.IsNullOrWhiteSpace(node.PrevText))
                {
                    if (dict.TryGetValue(node.PrevText, out var value))
                        node.Model.PL_ANM_previous_name = value.Model.PL_ANM_current_name ?? value.Model.PL_ANM_animation;
                    else node.Model.PL_ANM_previous_name = node.PrevText;
                } else node.Model.PL_ANM_previous_name = null;

                if (!string.IsNullOrWhiteSpace(node.NextText))
                {
                    if (dict.TryGetValue(node.NextText, out var value2))
                        node.Model.PL_ANM_next_name = value2.Model.PL_ANM_current_name ?? value2.Model.PL_ANM_animation;
                    else node.Model.PL_ANM_next_name = node.NextText;
                } else node.Model.PL_ANM_next_name = null;
            }
            Status = "Saved back to PRMVER_Model.";
        }
        protected void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));


    }

    public class NodeViewModel : INotifyPropertyChanged
    {
        public PRM_PL_ANM_Model Model { get; }
        public string DisplayName => Model.PL_ANM_current_name ?? Model.PL_ANM_animation ?? "<unnamed>";
        public double X { get => _x; set { _x = value; OnPropertyChanged(); } }
        public double Y { get => _y; set { _y = value; OnPropertyChanged(); } }
        private double _x;
        private double _y;

        private bool _isPrevMissing;
        public bool IsPrevMissing { get => _isPrevMissing; set { _isPrevMissing = value; OnPropertyChanged(); } }

        private bool _isNextMissing;
        public bool IsNextMissing { get => _isNextMissing; set { _isNextMissing = value; OnPropertyChanged(); } }

        private string _prevText;
        public string PrevText { get => _prevText; set { _prevText = value; OnPropertyChanged(); } }

        private string _nextText;
        public string NextText { get => _nextText; set { _nextText = value; OnPropertyChanged(); } }

        public NodeViewModel(PRM_PL_ANM_Model model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            PrevText = model.PL_ANM_previous_name ?? string.Empty;
            NextText = model.PL_ANM_next_name ?? string.Empty;
        }

        public string GetKeyString()
        {
            return Model.PL_ANM_current_name ?? Model.PL_ANM_animation ?? string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class LinkViewModel : INotifyPropertyChanged
    {
        private readonly NodeViewModel _from;
        private readonly NodeViewModel _to;
        public LinkViewModel(NodeViewModel from, NodeViewModel to) { _from = from; _to = to; }

        public double X1 => _from.X + 120; // center of node width 240
        public double Y1 => _from.Y + 18;  // header area
        public double X2 => _to.X + 120;
        public double Y2 => _to.Y + 18;

        public void RaisePositionChanged()
        {
            OnPropertyChanged(nameof(X1));
            OnPropertyChanged(nameof(Y1));
            OnPropertyChanged(nameof(X2));
            OnPropertyChanged(nameof(Y2));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
