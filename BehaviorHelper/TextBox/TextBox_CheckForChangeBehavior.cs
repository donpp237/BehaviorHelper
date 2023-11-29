using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace BehaviorHelper
{
    public class TextBox_CheckForChangeBehavior
    {
        public static readonly DependencyProperty CheckForChangeProperty = DependencyProperty.RegisterAttached("CheckForChange", typeof(Brush), typeof(TextBox_CheckForChangeBehavior),
                                                                           new UIPropertyMetadata(new SolidColorBrush(Colors.Black), ApplyChangeEvent));

        private static Brush m_originColor;
        private static string m_originText;

        public static void SetColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(CheckForChangeProperty, value);
        }

        public static Brush GetColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(CheckForChangeProperty);
        }

        public static void ApplyChangeEvent(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TextBox tb = obj as TextBox;
            if (tb == null)
                return;

            m_originText = "";
            m_originColor = tb.Foreground;

            SolidColorBrush brush = (SolidColorBrush)args.NewValue;
            if (brush.Color == default(Color))
                tb.TextChanged -= TextBoxTextChanged;
            else 
                tb.TextChanged += TextBoxTextChanged;
        }

        private static void TextBoxTextChanged(object sender, TextChangedEventArgs args)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;

            if (string.IsNullOrEmpty(m_originText) == true)
            {
                m_originText = tb.Text;
                return;
            }

            if (tb.Text != m_originText)
                tb.Foreground = GetColor((DependencyObject)tb);
            else
                tb.Foreground = m_originColor;
        }
    }
}
