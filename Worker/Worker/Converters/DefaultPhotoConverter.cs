using System;
using System.Globalization;
using Xamarin.Forms;

namespace Worker.Converters
{
    public class DefaultPhotoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ImageSource)value != null ? value : "default_photo.jpg";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}