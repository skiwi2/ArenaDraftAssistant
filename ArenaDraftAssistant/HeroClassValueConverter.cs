using System;
using System.Globalization;
using System.Windows.Data;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class HeroClassValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as HeroClass)?.Name ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
