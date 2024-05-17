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

namespace NSC_Toolbox.View {
    /// <summary>
    /// Логика взаимодействия для SkillEditorView.xaml
    /// </summary>
    public partial class SkillEditorView : Window {
        public SkillEditorView() {
            InitializeComponent();
            DataContext = new SkillEditorViewModel();
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

                DataObject dataObj = new DataObject(listBoxItem.Content as SkillEntryModel);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            SkillEditorViewModel VM = ((SkillEditorViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(SkillEntryModel)) as SkillEntryModel;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as SkillEntryModel;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.SkillList.IndexOf(sourcePerson);
            int targetIndex = VM.SkillList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.SkillList.Insert(targetIndex + 1, sourcePerson);
                VM.SkillList.RemoveAt(sourceIndex);
                VM.SelectedSkillIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.SkillList.Count + 1 > removeIndex) {
                    VM.SkillList.Insert(targetIndex, sourcePerson);
                    VM.SkillList.RemoveAt(removeIndex);
                    VM.SelectedSkillIndex = targetIndex;
                }
            }
        }

        private void LBoxSort_action_OnPreviewMouseMove(object sender, MouseEventArgs e) {
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

                DataObject dataObj = new DataObject(listBoxItem.Content as SkillActionModel);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_action_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            SkillEditorViewModel VM = ((SkillEditorViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(SkillActionModel)) as SkillActionModel;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as SkillActionModel;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.ActionList.IndexOf(sourcePerson);
            int targetIndex = VM.ActionList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.ActionList.Insert(targetIndex + 1, sourcePerson);
                VM.ActionList.RemoveAt(sourceIndex);
                VM.SelectedActionIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.ActionList.Count + 1 > removeIndex) {
                    VM.ActionList.Insert(targetIndex, sourcePerson);
                    VM.ActionList.RemoveAt(removeIndex);
                    VM.SelectedActionIndex = targetIndex;
                }
            }
        }

        private void LBoxSort_sound_OnPreviewMouseMove(object sender, MouseEventArgs e) {
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

                DataObject dataObj = new DataObject(listBoxItem.Content as SkillSoundModel);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_sound_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            SkillEditorViewModel VM = ((SkillEditorViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(SkillSoundModel)) as SkillSoundModel;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as SkillSoundModel;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.SoundList.IndexOf(sourcePerson);
            int targetIndex = VM.SoundList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.SoundList.Insert(targetIndex + 1, sourcePerson);
                VM.SoundList.RemoveAt(sourceIndex);
                VM.SelectedSoundIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.SoundList.Count + 1 > removeIndex) {
                    VM.SoundList.Insert(targetIndex, sourcePerson);
                    VM.SoundList.RemoveAt(removeIndex);
                    VM.SelectedSoundIndex = targetIndex;
                }
            }
        }

        private void LBoxSort_event_OnPreviewMouseMove(object sender, MouseEventArgs e) {
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

                DataObject dataObj = new DataObject(listBoxItem.Content as SkillEventModel);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_event_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            SkillEditorViewModel VM = ((SkillEditorViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(SkillEventModel)) as SkillEventModel;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as SkillEventModel;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.EventList.IndexOf(sourcePerson);
            int targetIndex = VM.EventList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.EventList.Insert(targetIndex + 1, sourcePerson);
                VM.EventList.RemoveAt(sourceIndex);
                VM.SelectedEventIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.EventList.Count + 1 > removeIndex) {
                    VM.EventList.Insert(targetIndex, sourcePerson);
                    VM.EventList.RemoveAt(removeIndex);
                    VM.SelectedEventIndex = targetIndex;
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
