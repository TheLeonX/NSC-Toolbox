using ModernWpf;
using NodeNetwork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Themes;

namespace NSC_Toolbox {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public class RelayCommand : ICommand {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter) {
            this.execute(parameter);
        }
    }

    public static class DragDropExtension {
        public static readonly DependencyProperty ScrollOnDragDropProperty =
            DependencyProperty.RegisterAttached("ScrollOnDragDrop",
                typeof(bool),
                typeof(DragDropExtension),
                new PropertyMetadata(false, HandleScrollOnDragDropChanged));

        public static bool GetScrollOnDragDrop(DependencyObject element) {
            if (element == null) {
                throw new ArgumentNullException("element");
            }

            return (bool)element.GetValue(ScrollOnDragDropProperty);
        }

        public static void SetScrollOnDragDrop(DependencyObject element, bool value) {
            if (element == null) {
                throw new ArgumentNullException("element");
            }

            element.SetValue(ScrollOnDragDropProperty, value);
        }

        private static void HandleScrollOnDragDropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            FrameworkElement container = d as FrameworkElement;

            if (d == null) {
                Debug.Fail("Invalid type!");
                return;
            }

            Unsubscribe(container);

            if (true.Equals(e.NewValue)) {
                Subscribe(container);
            }
        }

        private static void Subscribe(FrameworkElement container) {
            container.PreviewDragOver += OnContainerPreviewDragOver;
        }

        private static void OnContainerPreviewDragOver(object sender, DragEventArgs e) {
            FrameworkElement container = sender as FrameworkElement;

            if (container == null) {
                return;
            }

            ScrollViewer scrollViewer = GetFirstVisualChild<ScrollViewer>(container);

            if (scrollViewer == null) {
                return;
            }

            double tolerance = 10;
            double verticalPos = e.GetPosition(container).Y;
            double offset = 2;

            if (verticalPos < tolerance) // Top of visible list? 
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - offset); //Scroll up. 
            } else if (verticalPos > container.ActualHeight - tolerance) //Bottom of visible list? 
              {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + offset); //Scroll down.     
            }
        }

        private static void Unsubscribe(FrameworkElement container) {
            container.PreviewDragOver -= OnContainerPreviewDragOver;
        }

        private static T GetFirstVisualChild<T>(DependencyObject depObj) where T : DependencyObject {
            if (depObj != null) {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T) {
                        return (T)child;
                    }

                    T childItem = GetFirstVisualChild<T>(child);
                    if (childItem != null) {
                        return childItem;
                    }
                }
            }

            return null;
        }
    }

    public partial class App : Application {

        public App() {

            InitializeComponent();
        }

        private void App_Startup(object sender, StartupEventArgs e) {
            NNViewRegistrar.RegisterSplat();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}
