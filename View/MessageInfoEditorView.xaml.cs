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
    /// Логика взаимодействия для MessageInfoEditorView.xaml
    /// </summary>
    public partial class MessageInfoEditorView : Window
    {
        public MessageInfoEditorView()
        {
            InitializeComponent();
            DataContext = new MessageInfoViewModel();
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

                DataObject dataObj = new DataObject(listBoxItem.Content as MessageInfoModel);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            MessageInfoViewModel VM = ((MessageInfoViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(MessageInfoModel)) as MessageInfoModel;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as MessageInfoModel;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.MessageInfo_preview_List.IndexOf(sourcePerson);
            int targetIndex = VM.MessageInfo_preview_List.IndexOf(targetPerson);


            if (sourceIndex < targetIndex) {

                for (int i = 0; i < VM.MessageInfo_List.Count; i++) {
                    MessageInfoModel entry = (MessageInfoModel)VM.MessageInfo_List[i][sourceIndex].Clone();
                    VM.MessageInfo_List[i].Insert(targetIndex + 1, entry);
                    VM.MessageInfo_List[i].RemoveAt(sourceIndex);
                    VM.SelectedMessageIndex = targetIndex;
                }

                
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.MessageInfo_preview_List.Count + 1 > removeIndex) {
                    for (int i = 0; i < VM.MessageInfo_List.Count; i++) {
                        MessageInfoModel entry = (MessageInfoModel)VM.MessageInfo_List[i][sourceIndex].Clone();
                        VM.MessageInfo_List[i].Insert(targetIndex, entry);
                        VM.MessageInfo_List[i].RemoveAt(removeIndex);
                        VM.SelectedMessageIndex = targetIndex;
                    }
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
