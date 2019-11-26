using System;
using System.Globalization;
using Xamarin.Forms;

namespace MobileTasker
{
    public class BoolToTextDecorationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var completed = (bool) value;
            var result = completed ? TextDecorations.Strikethrough : TextDecorations.None;
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var decoration = (TextDecorations) value;
            if (decoration == TextDecorations.Strikethrough)
                return true;
            return false;
        }
    }
}