using NSC_Toolbox.Model;
using NSC_Toolbox.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace NSC_Toolbox.View {
    /// <summary>
    /// Логика взаимодействия для PRMEditorView.xaml
    /// </summary>
    public partial class PRMEditorView : Window {

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var dpi = VisualTreeHelper.GetDpi(this);
            double scaleX = 1 / dpi.DpiScaleX;
            double scaleY = 1 / dpi.DpiScaleY;
            RootGrid.LayoutTransform = new ScaleTransform(scaleX, scaleY);
        }


        public PRMEditorView() {
            InitializeComponent();
            DataContext = new PRMEditorViewModel();

        }

        private void BringSelectionIntoView(object sender, SelectionChangedEventArgs e) {
            Selector selector = sender as Selector;
            if (selector is ListBox) {
                (selector as ListBox).ScrollIntoView(selector.SelectedItem);
            }
        }
        private void LBoxSort_VER_OnPreviewMouseMove(object sender, MouseEventArgs e) {
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

                DataObject dataObj = new DataObject(listBoxItem.Content as PRMVER_Model);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_VER_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            PRMEditorViewModel VM = ((PRMEditorViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(PRMVER_Model)) as PRMVER_Model;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as PRMVER_Model;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.VerList.IndexOf(sourcePerson);
            int targetIndex = VM.VerList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.VerList.Insert(targetIndex + 1, sourcePerson);
                VM.VerList.RemoveAt(sourceIndex);
                VM.SelectedVerIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.VerList.Count + 1 > removeIndex) {
                    VM.VerList.Insert(targetIndex, sourcePerson);
                    VM.VerList.RemoveAt(removeIndex);
                    VM.SelectedVerIndex = targetIndex;
                }
            }
        }

        private void LBoxSort_PL_ANM_OnPreviewMouseMove(object sender, MouseEventArgs e) {
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

                DataObject dataObj = new DataObject(listBoxItem.Content as PRM_PL_ANM_Model);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_PL_ANM_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            PRMEditorViewModel VM = ((PRMEditorViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(PRM_PL_ANM_Model)) as PRM_PL_ANM_Model;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as PRM_PL_ANM_Model;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.PL_ANM_List.IndexOf(sourcePerson);
            int targetIndex = VM.PL_ANM_List.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.PL_ANM_List.Insert(targetIndex + 1, sourcePerson);
                VM.PL_ANM_List.RemoveAt(sourceIndex);
                VM.SelectedPL_ANMIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.PL_ANM_List.Count + 1 > removeIndex) {
                    VM.PL_ANM_List.Insert(targetIndex, sourcePerson);
                    VM.PL_ANM_List.RemoveAt(removeIndex);
                    VM.SelectedPL_ANMIndex = targetIndex;
                }
            }
        }
        private void LBoxSort_Function_OnPreviewMouseMove(object sender, MouseEventArgs e) {
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

                DataObject dataObj = new DataObject(listBoxItem.Content as PRMFunction_Model);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_Function_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            PRMEditorViewModel VM = ((PRMEditorViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(PRMFunction_Model)) as PRMFunction_Model;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as PRMFunction_Model;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.FunctionList.IndexOf(sourcePerson);
            int targetIndex = VM.FunctionList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.FunctionList.Insert(targetIndex + 1, sourcePerson);
                VM.FunctionList.RemoveAt(sourceIndex);
                VM.SelectedFunctionIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.FunctionList.Count + 1 > removeIndex) {
                    VM.FunctionList.Insert(targetIndex, sourcePerson);
                    VM.FunctionList.RemoveAt(removeIndex);
                    VM.SelectedFunctionIndex = targetIndex;
                }
            }
        }
        private void LBoxSort_Projectile_OnPreviewMouseMove(object sender, MouseEventArgs e) {
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

                DataObject dataObj = new DataObject(listBoxItem.Content as PRMProjectile_Model);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_Projectile_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            PRMEditorViewModel VM = ((PRMEditorViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(PRMProjectile_Model)) as PRMProjectile_Model;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as PRMProjectile_Model;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.ProjectileList.IndexOf(sourcePerson);
            int targetIndex = VM.ProjectileList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.ProjectileList.Insert(targetIndex + 1, sourcePerson);
                VM.ProjectileList.RemoveAt(sourceIndex);
                VM.SelectedProjectileIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.ProjectileList.Count + 1 > removeIndex) {
                    VM.ProjectileList.Insert(targetIndex, sourcePerson);
                    VM.ProjectileList.RemoveAt(removeIndex);
                    VM.SelectedProjectileIndex = targetIndex;
                }
            }
        }
        private void LBoxSort_Collision_OnPreviewMouseMove(object sender, MouseEventArgs e) {
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

                DataObject dataObj = new DataObject(listBoxItem.Content as PRMCollision_Model);
                DragDrop.DoDragDrop(lb, dataObj, DragDropEffects.Move);    //Call method
            }
        }

        private void LBoxSort_Collision_OnDrop(object sender, DragEventArgs e) {
            ListBox lb = (ListBox)sender;
            PRMEditorViewModel VM = ((PRMEditorViewModel)this.DataContext);
            var pos = e.GetPosition(lb);      //Get location 
            var result = VisualTreeHelper.HitTest(lb, pos);      //According to the position to get the result
            if (result == null) {
                return;      //Cannot find return
            }
            #region Finding metadata
            var sourcePerson = e.Data.GetData(typeof(PRMCollision_Model)) as PRMCollision_Model;
            if (sourcePerson == null) {
                return;
            }
            #endregion
            #region Find target data
            var listBoxItem = Utils.FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null) {
                return;
            }
            var targetPerson = listBoxItem.Content as PRMCollision_Model;
            if (ReferenceEquals(targetPerson, sourcePerson)) {
                return;
            }
            #endregion
            int sourceIndex = VM.CollisionList.IndexOf(sourcePerson);
            int targetIndex = VM.CollisionList.IndexOf(targetPerson);



            if (sourceIndex < targetIndex) {
                VM.CollisionList.Insert(targetIndex + 1, sourcePerson);
                VM.CollisionList.RemoveAt(sourceIndex);
                VM.SelectedCollisionIndex = targetIndex;
            } else {
                int removeIndex = sourceIndex + 1;
                if (VM.CollisionList.Count + 1 > removeIndex) {
                    VM.CollisionList.Insert(targetIndex, sourcePerson);
                    VM.CollisionList.RemoveAt(removeIndex);
                    VM.SelectedCollisionIndex = targetIndex;
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
