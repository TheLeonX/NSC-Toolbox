using ModernWpf;
using NodeNetwork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public static class EnumExtensions {
        private static void CheckIsEnum<T>(bool withFlags) {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(string.Format("Type '{0}' is not an enum", typeof(T).FullName));
            if (withFlags && !Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
                throw new ArgumentException(string.Format("Type '{0}' doesn't have the 'Flags' attribute", typeof(T).FullName));
        }

        public static bool IsFlagSet<T>(this T value, T flag) where T : struct {
            CheckIsEnum<T>(true);
            long lValue = Convert.ToInt64(value);
            long lFlag = Convert.ToInt64(flag);
            return (lValue & lFlag) != 0;
        }

        public static IEnumerable<T> GetFlags<T>(this T value) where T : struct {
            CheckIsEnum<T>(true);
            foreach (T flag in Enum.GetValues(typeof(T)).Cast<T>()) {
                if (value.IsFlagSet(flag))
                    yield return flag;
            }
        }

        public static T SetFlags<T>(this T value, T flags, bool on) where T : struct {
            CheckIsEnum<T>(true);
            long lValue = Convert.ToInt64(value);
            long lFlag = Convert.ToInt64(flags);
            if (on) {
                lValue |= lFlag;
            } else {
                lValue &= (~lFlag);
            }
            return (T)Enum.ToObject(typeof(T), lValue);
        }

        public static T SetFlags<T>(this T value, T flags) where T : struct {
            return value.SetFlags(flags, true);
        }

        public static T ClearFlags<T>(this T value, T flags) where T : struct {
            return value.SetFlags(flags, false);
        }

        public static T CombineFlags<T>(this IEnumerable<T> flags) where T : struct {
            CheckIsEnum<T>(true);
            long lValue = 0;
            foreach (T flag in flags) {
                long lFlag = Convert.ToInt64(flag);
                lValue |= lFlag;
            }
            return (T)Enum.ToObject(typeof(T), lValue);
        }

        public static string GetDescription<T>(this T value) where T : struct {
            CheckIsEnum<T>(false);
            string name = Enum.GetName(typeof(T), value);
            if (name != null) {
                FieldInfo field = typeof(T).GetField(name);
                if (field != null) {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null) {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
    public static class DisallowSpecialCharactersTextboxBehavior {
        public static DependencyProperty DisallowSpecialCharactersProperty =
            DependencyProperty.RegisterAttached("DisallowSpecialCharacters", typeof(bool), typeof(DisallowSpecialCharactersTextboxBehavior), new PropertyMetadata(DisallowSpecialCharactersChanged));

        public static void SetDisallowSpecialCharacters(TextBox textBox, bool disallow) {
            textBox.SetValue(DisallowSpecialCharactersProperty, disallow);
        }

        public static bool GetDisallowSpecialCharacters(TextBox textBox) {
            return (bool)textBox.GetValue(DisallowSpecialCharactersProperty);
        }

        private static void DisallowSpecialCharactersChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e) {
            var tb = dependencyObject as TextBox;
            if (tb != null) {

                if ((bool)e.NewValue) {
                    tb.PreviewTextInput += tb_PreviewTextInput;
                    tb.AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(tb_Pasting));
                } else {
                    tb.PreviewTextInput -= tb_PreviewTextInput;
                    tb.RemoveHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(tb_Pasting));
                }

            }
        }

        private static void tb_Pasting(object sender, DataObjectPastingEventArgs e) {
            var pastedText = e.DataObject.GetData(typeof(string)) as string;

            Path.GetInvalidFileNameChars().ToList().ForEach(c => {
                if (pastedText.Contains(c)) {
                    e.CancelCommand();
                }

            });
        }

        private static void tb_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {
            if (Path.GetInvalidFileNameChars().ToList().ConvertAll(x => x.ToString()).Contains(e.Text)) {
                e.Handled = true;
            }

        }
    }
    public partial class App : Application {

        public App() {

            InitializeComponent();
        }

        private void App_Startup(object sender, StartupEventArgs e) {
            NNViewRegistrar.RegisterSplat();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


            // Get the saved language (e.g., "en-US" or "ru-RU")
            string lang = NSC_Toolbox.Properties.Settings.Default.Language;

            // Get the merged dictionaries collection
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            // Find and remove the existing localization dictionary
            ResourceDictionary localizationDictionary = null;
            foreach (var dict in mergedDictionaries)
            {
                if (dict.Source != null && dict.Source.OriginalString.Contains("Resources/Localization/lang.xaml"))
                {
                    localizationDictionary = dict;
                    break;
                }
            }
            if (localizationDictionary != null)
            {
                mergedDictionaries.Remove(localizationDictionary);
            }

            // Load the appropriate localization dictionary based on the language
            var newDict = new ResourceDictionary();
            if (lang == "ru-RU")
                newDict.Source = new Uri("Resources/Localization/lang.ru-RU.xaml", UriKind.Relative);
            else
                newDict.Source = new Uri("Resources/Localization/lang.xaml", UriKind.Relative);

            // Add the new dictionary to the merged dictionaries
            mergedDictionaries.Add(newDict);
        }
    }
}
