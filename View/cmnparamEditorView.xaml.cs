using NSC_Toolbox.Model;
using NSC_Toolbox.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NSC_Toolbox.View
{
    /// <summary>
    /// Логика взаимодействия для cmnparamEditorView.xaml
    /// </summary>
    public partial class cmnparamEditorView : Window
    {
        public cmnparamEditorView()
        {
            InitializeComponent();
            DataContext = new cmnparamViewModel();
        }
        private void BringSelectionIntoView(object sender, SelectionChangedEventArgs e) {
            Selector selector = sender as Selector;
            if (selector is ListBox) {
                (selector as ListBox).ScrollIntoView(selector.SelectedItem);
            }
        }

        private void LBoxSort_Player_OnPreviewMouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {

                ListBox lb = (ListBox)sender;
                var pos = e.GetPosition(lb);  // Get location 

                #region source location
                HitTestResult result = VisualTreeHelper.HitTest(lb, pos);    //According to the position to get the result
                if (result == null) {
                    return;        //Cannot find return
                }
                var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
                if (listBoxItem == null || listBoxItem.Content != lb.SelectedItem) {
                    return;
                }
                #endregion

                DataObject dataObj = new DataObject(listBoxItem.Content as player_sndModel);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_Player_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            cmnparamViewModel VM = ((cmnparamViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(player_sndModel)) as player_sndModel;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as player_sndModel;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.PlayerSndList.IndexOf(sourcePerson);
            int targetIndex = VM.PlayerSndList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.PlayerSndList.Insert(targetIndex + 1, sourcePerson);
                VM.PlayerSndList.RemoveAt(sourceIndex);
                VM.SelectedPlayerSndIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.PlayerSndList.Count + 1 > removeIndex) {
                    VM.PlayerSndList.Insert(targetIndex, sourcePerson);
                    VM.PlayerSndList.RemoveAt(removeIndex);
                    VM.SelectedPlayerSndIndex = targetIndex;
                }
            }
        }
        private void LBoxSort_TeamJutsu_OnPreviewMouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {

                ListBox lb = (ListBox)sender;
                var pos = e.GetPosition(lb);  // Get location 

                #region source location
                HitTestResult result = VisualTreeHelper.HitTest(lb, pos);    //According to the position to get the result
                if (result == null) {
                    return;        //Cannot find return
                }
                var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
                if (listBoxItem == null || listBoxItem.Content != lb.SelectedItem) {
                    return;
                }
                #endregion

                DataObject dataObj = new DataObject(listBoxItem.Content as pair_spl_sndModel);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_TeamJutsu_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            cmnparamViewModel VM = ((cmnparamViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(pair_spl_sndModel)) as pair_spl_sndModel;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as pair_spl_sndModel;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.PairSplList.IndexOf(sourcePerson);
            int targetIndex = VM.PairSplList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.PairSplList.Insert(targetIndex + 1, sourcePerson);
                VM.PairSplList.RemoveAt(sourceIndex);
                VM.SelectedPairSplIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.PairSplList.Count + 1 > removeIndex) {
                    VM.PairSplList.Insert(targetIndex, sourcePerson);
                    VM.PairSplList.RemoveAt(removeIndex);
                    VM.SelectedPairSplIndex = targetIndex;
                }
            }
        }
        internal static class Utils {
            //Find the parent element according to the child element
            public static T FindVisualParent<T>(DependencyObject obj) where T : class {
                while (obj != null) {
                    if (obj is T)
                        return obj as T;

                    obj = VisualTreeHelper.GetParent(obj);
                }
                return null;
            }
        }
    }
}
