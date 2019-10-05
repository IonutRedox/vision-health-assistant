using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace VisionHealthAssistant.UI.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value,Type targetType,object parameter,CultureInfo culture)
        {
            bool isVisible = (bool)value;
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value,Type targetType,object parameter,CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
