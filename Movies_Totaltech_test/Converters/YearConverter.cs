using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Movies_Totaltech_test.Converters
{
    public class YearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return System.Convert.ToDateTime(value).ToString("yyyy");
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return System.Convert.ToDateTime(value).ToString("yyyy");
            }
            else
            {
                return "";
            }
        }
    }
}
