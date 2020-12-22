using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Movies_Totaltech_test.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        private static string BaseImageUrl => "https://image.tmdb.org/t/p/w500";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return $"{BaseImageUrl}{value}";
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
                return $"{BaseImageUrl}{value}";
            }
            else
            {
                return "";
            }
        }
    }
}
