using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace ArenaDraftAssistant
{
    class DropProbabilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pair = value as KeyValuePair<int, double>?;
            if (pair == null) return string.Empty;

            var key = pair.Value.Key;
            var val = pair.Value.Value;

            return $"{val:P1} - {key:D} drops";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
