using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VisionHealthAssistant.UI.Helper
{
    public static class TextBoxHelper
    {
        private static readonly Regex regex = new Regex("^[0-9]");

        public static bool GetOnlyIntegers(TextBox textBox)
        {
            return (bool)textBox.GetValue(OnlyIntegerProperty);
        }

        public static void SetOnlyInteger(TextBox textBox,bool value)
        {
            textBox.SetValue(OnlyIntegerProperty,value);
        }

        public static readonly DependencyProperty OnlyIntegerProperty =
            DependencyProperty.RegisterAttached(
                "OnlyInteger",typeof(bool),typeof(TextBoxHelper),
                new PropertyMetadata(false,OnOnlyIntegerChanged));

        static void OnOnlyIntegerChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;

            if(textBox == null) {
                throw new InvalidOperationException("This property can only be applied to TextBox");
            }

            var oldValue = (bool)e.OldValue;
            if(oldValue) {
                textBox.PreviewTextInput -= OnPreviewTextInput;
            }

            var newValue = (bool)e.NewValue;
            if(newValue) {
                textBox.PreviewTextInput += OnPreviewTextInput;
            }
        }

        static void OnPreviewTextInput(object sender,TextCompositionEventArgs e)
        {
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
