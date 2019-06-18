using System;
using System.Globalization;
using Xamarin.Forms;

namespace Worker.Converters
{
    public class IntHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((TimeSpan)value).TotalHours.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Int32.TryParse((string) value, out int intValue))
            {
                return new TimeSpan(intValue, 0, 0);
            }
            return new TimeSpan(0, 0, 0);
        }
    }
}