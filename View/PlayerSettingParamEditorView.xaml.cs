﻿using NSC_Toolbox.Model;
using NSC_Toolbox.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace NSC_Toolbox.View {
    /// <summary>
    /// Логика взаимодействия для PlayerSettingParamEditorView.xaml
    /// </summary>
    public partial class PlayerSettingParamEditorView : Window {
        public PlayerSettingParamEditorView() {
            InitializeComponent();
            DataContext = new PlayerSettingParamViewModel();
        }
        private void BringSelectionIntoView(object sender, SelectionChangedEventArgs e) {
            Selector selector = sender as Selector;
            if (selector is ListBox) {
                (selector as ListBox).ScrollIntoView(selector.SelectedItem);
            }
        }
        private void LBoxSort_OnPreviewMouseMove(object sender, MouseEventArgs e) {
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

                DataObject dataObj = new DataObject(listBoxItem.Content as PlayerSettingParamModel);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            PlayerSettingParamViewModel VM = ((PlayerSettingParamViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(PlayerSettingParamModel)) as PlayerSettingParamModel;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as PlayerSettingParamModel;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.PlayerSettingParamList.IndexOf(sourcePerson);
            int targetIndex = VM.PlayerSettingParamList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.PlayerSettingParamList.Insert(targetIndex + 1, sourcePerson);
                VM.PlayerSettingParamList.RemoveAt(sourceIndex);
                VM.SelectedPSPIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.PlayerSettingParamList.Count + 1 > removeIndex) {
                    VM.PlayerSettingParamList.Insert(targetIndex, sourcePerson);
                    VM.PlayerSettingParamList.RemoveAt(removeIndex);
                    VM.SelectedPSPIndex = targetIndex;
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
