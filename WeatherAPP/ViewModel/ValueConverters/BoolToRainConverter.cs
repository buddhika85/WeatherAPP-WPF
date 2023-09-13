using System;
using System.Globalization;
using System.Windows.Data;

namespace WeatherAPP.ViewModel.ValueConverters
{
    public class BoolToRainConverter : IValueConverter
    {
        private const string IsRaining = "Currently raining";
        private const string IsNotRaining = "Currently not raining";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return IsRaining;

            return IsNotRaining;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).Equals(IsRaining);
        }
    }
}
