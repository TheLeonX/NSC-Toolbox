using NSC_Toolbox.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NSC_Toolbox.View
{
    public partial class PRMNodeEditorView : Window
    {
        private bool _isDraggingNode;
        private Point _nodeDragStart;
        private NodeViewModel _dragNode;

        // Для перетаскивания связей
        private bool _isDraggingConn;
        private NodeViewModel _connStartNode;
        private bool _connIsPrevHandle; // true если начал с Prev, false если с Next

        // Панорамирование (middle mouse)
        private bool _isPanning;
        private Point _panStart;
        private double _origHOffset;
        private double _origVOffset;
        private string _connHandleType; // "Prev", "Next", "Current"
        public PRMNodeEditorView()
        {
            InitializeComponent();
            DataContext = new PRMNodeEditorViewModel();
        }

        // --- перетаскивание узла (header) ---
        private void NodeHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // не начинаем перетаскивание узла, если сейчас перетаскиваем соединение
            if (_isDraggingConn) return;

            var fe = sender as FrameworkElement;
            if (fe == null) return;
            _dragNode = fe.DataContext as NodeViewModel;
            if (_dragNode == null) return;
            _isDraggingNode = true;
            _nodeDragStart = e.GetPosition(MainCanvas);
            fe.CaptureMouse();
            e.Handled = true;
        }

        private void NodeHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDraggingNode || _dragNode == null) return;
            var pos = e.GetPosition(MainCanvas);
            double dx = pos.X - _nodeDragStart.X;
            double dy = pos.Y - _nodeDragStart.Y;
            _dragNode.X += dx;
            _dragNode.Y += dy;
            _nodeDragStart = pos;

            // расширяем холст прямо из code-behind (имитация infinite canvas)
            double needW = _dragNode.X + 500;
            double needH = _dragNode.Y + 400;
            if (needW > MainCanvas.Width) MainCanvas.Width = needW;
            if (needH > MainCanvas.Height) MainCanvas.Height = needH;

            var vm = this.DataContext as PRMNodeEditorViewModel;
            vm?.RaiseAllLinksPositionChanged();
            e.Handled = true;
        }

        private void NodeHeader_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!_isDraggingNode) return;
            var fe = sender as FrameworkElement;
            if (fe != null) fe.ReleaseMouseCapture();
            _isDraggingNode = false;
            _dragNode = null;
            e.Handled = true;
        }

        // --- перетаскивание соединений ---
        private void ConnPrevBehind_MouseDown(object sender, MouseButtonEventArgs e) => StartConnDrag(sender, "Prev", e);
        private void ConnPrev_MouseDown(object sender, MouseButtonEventArgs e) => StartConnDrag(sender, "Prev", e);
        private void ConnNext_MouseDown(object sender, MouseButtonEventArgs e) => StartConnDrag(sender, "Next", e);
        private void ConnCurrent_MouseDown(object sender, MouseButtonEventArgs e) => StartConnDrag(sender, "Current", e);
        private bool _isConnHandlersAttached = false;
        private void StartConnDrag(object sender, string handleType, MouseButtonEventArgs e)
        {
            var fe = sender as FrameworkElement;
            if (fe == null) return;
            _connStartNode = fe.DataContext as NodeViewModel;
            if (_connStartNode == null) return;

            _isDraggingConn = true;
            _connHandleType = handleType;

            // стартовая позиция — центр ручки в координатах канваса
            var handleCenter = fe.TranslatePoint(new Point(fe.ActualWidth / 2.0, fe.ActualHeight / 2.0), MainCanvas);
            DragLine.X1 = handleCenter.X;
            DragLine.Y1 = handleCenter.Y;
            DragLine.X2 = handleCenter.X;
            DragLine.Y2 = handleCenter.Y;
            DragLine.Visibility = Visibility.Visible;

            if (!_isConnHandlersAttached)
            {
                MainCanvas.MouseMove += MainCanvas_ConnMove;
                MainCanvas.MouseLeftButtonUp += MainCanvas_ConnUp;
                _isConnHandlersAttached = true;
            }

            try { Mouse.Capture(MainCanvas, CaptureMode.SubTree); } catch { }

            e.Handled = true;
        }
        // Новый обработчик движения (подписанный на MainCanvas.MouseMove)
        private void MainCanvas_ConnMove(object sender, MouseEventArgs e)
        {
            if (!_isDraggingConn) return;
            var pt = e.GetPosition(MainCanvas);
            DragLine.X2 = pt.X;
            DragLine.Y2 = pt.Y;
            e.Handled = true;
        }

        // Новый обработчик отпускания (подписанный на MainCanvas.MouseLeftButtonUp)
        private void MainCanvas_ConnUp(object sender, MouseButtonEventArgs e)
        {
            if (!_isDraggingConn) return;
            var pt = e.GetPosition(MainCanvas);

            NodeViewModel targetNode = null;
            HitTestResult result = VisualTreeHelper.HitTest(MainCanvas, pt);
            if (result != null)
            {
                DependencyObject cur = result.VisualHit;
                while (cur != null)
                {
                    if (cur is FrameworkElement fe && fe.DataContext is NodeViewModel nm)
                    {
                        targetNode = nm;
                        break;
                    }
                    cur = VisualTreeHelper.GetParent(cur);
                }
            }

            var vm = DataContext as PRMNodeEditorViewModel;
            if (vm != null && _connStartNode != null)
            {
                if (targetNode != null && !ReferenceEquals(targetNode, _connStartNode))
                {
                    switch (_connHandleType)
                    {
                        case "Prev":
                            _connStartNode.PrevText = targetNode.GetKeyString();
                            _connStartNode.IsPrevMissing = false;
                            break;
                        case "Next":
                            _connStartNode.NextText = targetNode.GetKeyString();
                            _connStartNode.IsNextMissing = false;
                            break;
                        case "Current":
                            // Current handle: делаем так, чтобы цель считала источник предыдущим
                            targetNode.PrevText = _connStartNode.GetKeyString();
                            targetNode.IsPrevMissing = false;
                            break;
                    }
                    vm.RebuildLinks();
                    vm.Status = $"Linked '{_connStartNode.DisplayName}' -> '{targetNode.DisplayName}' ({_connHandleType})";
                } else
                {
                    // брошено в пустое место — очищаем соответствующее поле
                    if (_connHandleType == "Prev")
                    {
                        _connStartNode.PrevText = string.Empty;
                        _connStartNode.IsPrevMissing = true;
                    } else if (_connHandleType == "Next")
                    {
                        _connStartNode.NextText = string.Empty;
                        _connStartNode.IsNextMissing = true;
                    } else if (_connHandleType == "Current")
                    {
                        // ничего не делаем если Current был брошен в пустоту — логично оставить цель нетронутой
                    }
                    vm.RebuildLinks();
                    vm.Status = $"Cleared link for '{_connStartNode.DisplayName}' ({_connHandleType})";
                }
            }

            EndConnDragCleanup();
            e.Handled = true;
        }


        private void Conn_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDraggingConn) return;
            // если мышь не захвачена — прерываем (защита от блокировки)
            if (Mouse.Captured == null) { EndConnDragAborted(); return; }

            var pt = e.GetPosition(MainCanvas);
            DragLine.X2 = pt.X;
            DragLine.Y2 = pt.Y;
            e.Handled = true;
        }

        private void Conn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!_isDraggingConn) return;
            // safety: получаем позицию по MainCanvas
            var pt = e.GetPosition(MainCanvas);

            // хит-тест: ищем ближайшую ноду (ищем родителя с DataContext NodeViewModel)
            NodeViewModel targetNode = null;
            HitTestResult result = VisualTreeHelper.HitTest(MainCanvas, pt);
            if (result != null)
            {
                DependencyObject cur = result.VisualHit;
                while (cur != null)
                {
                    if (cur is FrameworkElement fe && fe.DataContext is NodeViewModel nm)
                    {
                        targetNode = nm;
                        break;
                    }
                    cur = VisualTreeHelper.GetParent(cur);
                }
            }

            var vm = DataContext as PRMNodeEditorViewModel;
            if (vm != null && _connStartNode != null)
            {
                if (targetNode != null && !ReferenceEquals(targetNode, _connStartNode))
                {
                    if (_connIsPrevHandle)
                    {
                        _connStartNode.PrevText = targetNode.GetKeyString();
                        _connStartNode.IsPrevMissing = false;
                    } else
                    {
                        _connStartNode.NextText = targetNode.GetKeyString();
                        _connStartNode.IsNextMissing = false;
                    }
                    vm.RebuildLinks();
                    vm.Status = $"Linked '{_connStartNode.DisplayName}' -> '{targetNode.DisplayName}'";
                } else
                {
                    // брошено в пустое место — очищаем поле
                    if (_connIsPrevHandle)
                    {
                        _connStartNode.PrevText = string.Empty;
                        _connStartNode.IsPrevMissing = true;
                    } else
                    {
                        _connStartNode.NextText = string.Empty;
                        _connStartNode.IsNextMissing = true;
                    }
                    vm.RebuildLinks();
                    vm.Status = $"Cleared link for '{_connStartNode.DisplayName}'";
                }
            }

            EndConnDragCleanup();
            e.Handled = true;
        }
        private void EndConnDragCleanup()
        {
            DragLine.Visibility = Visibility.Collapsed;
            _isDraggingConn = false;
            _connStartNode = null;
            _connHandleType = null;
            _connIsPrevHandle = false;

            // отписываемся от событий канваса
            if (_isConnHandlersAttached)
            {
                try { MainCanvas.MouseMove -= MainCanvas_ConnMove; } catch { }
                try { MainCanvas.MouseLeftButtonUp -= MainCanvas_ConnUp; } catch { }
                _isConnHandlersAttached = false;
            }

            try { Mouse.Capture(null); } catch { }
            try { MainCanvas.ReleaseMouseCapture(); } catch { }
        }

        // безопасный Abort (в случае ошибок)
        private void EndConnDragAborted()
        {
            EndConnDragCleanup();
            var vm = DataContext as PRMNodeEditorViewModel;
            if (vm != null) vm.Status = "Connection drag aborted";
        }

        // добавьте обработчик окна для потери захвата/деактивации — защитит от "залипания"
        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);
            if (_isDraggingConn) EndConnDragAborted();
            if (_isDraggingNode)
            {
                _isDraggingNode = false;
                _dragNode = null;
                try { Mouse.Capture(null); } catch { }
            }
        }
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            if (_isDraggingConn) EndConnDragAborted();
            if (_isDraggingNode)
            {
                _isDraggingNode = false;
                _dragNode = null;
                try { Mouse.Capture(null); } catch { }
            }
        }

        // --- панорамирование ScrollViewer средней кнопкой ---
        private void MainScroll_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                _isPanning = true;
                _panStart = e.GetPosition(this);
                _origHOffset = MainScroll.HorizontalOffset;
                _origVOffset = MainScroll.VerticalOffset;
                MainScroll.CaptureMouse();
                e.Handled = true;
            }
        }

        private void MainScroll_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isPanning) return;
            var pos = e.GetPosition(this);
            var dx = pos.X - _panStart.X;
            var dy = pos.Y - _panStart.Y;
            MainScroll.ScrollToHorizontalOffset(_origHOffset - dx);
            MainScroll.ScrollToVerticalOffset(_origVOffset - dy);
            e.Handled = true;
        }

        private void MainScroll_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isPanning)
            {
                _isPanning = false;
                try { MainScroll.ReleaseMouseCapture(); } catch { }
                e.Handled = true;
            }
        }
    }
}
