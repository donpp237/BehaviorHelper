using System.Windows;
using System.Windows.Controls;

namespace BehaviorHelper
{
    public class TextBox_SelectAllBehavior
    {
        public static readonly DependencyProperty SelectAllProperty = DependencyProperty.RegisterAttached("SelectAll", typeof(bool), typeof(TextBox_SelectAllBehavior),
                                                                      new UIPropertyMetadata(false, ApplySelectAllEvent));

        public static void SetSelect(DependencyObject obj, bool value)
        {
            obj.SetValue(SelectAllProperty, value);
        }

        public static void ApplySelectAllEvent(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TextBox tb = obj as TextBox;
            if (tb == null)
                return;

            bool isApply = (bool)args.NewValue;

            if (isApply == true)
                tb.MouseDoubleClick += TextBoxMouseDoubleClick;
            else
                tb.MouseDoubleClick -= TextBoxMouseDoubleClick;
        }

        private static void TextBoxMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs args)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;

            tb.SelectAll();
        }
    }
}
