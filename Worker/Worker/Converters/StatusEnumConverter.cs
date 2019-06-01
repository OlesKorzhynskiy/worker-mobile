using System;
using System.Globalization;
using Worker.Enums;
using Xamarin.Forms;

namespace Worker.Converters
{
    public class StatusEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            switch ((StatusEnum)value)
            {
                case StatusEnum.WaitingForEmployee:
                    return "Очікує на працівника";
                case StatusEnum.WaitingForEmployerConfirmation:
                    return "Очікується підтвердження роботодавця";
                case StatusEnum.WaitingForEmployeeConfirmation:
                    return "Очікується підтвердження працівника";
                case StatusEnum.InProgress:
                    return "Виконується";
                case StatusEnum.Done:
                    return "Завершено";
            }

            throw new Exception("Not known status: " + ((StatusEnum)value));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}