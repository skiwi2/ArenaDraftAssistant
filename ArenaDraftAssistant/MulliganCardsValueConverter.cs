using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ArenaDraftAssistant
{
    class MulliganCardsValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var amount = value as int?;
            if (amount == null) return string.Empty;

            var cards = (amount.Value == 1) ? "card" : "cards";
            return $"Mulligan {amount.Value} {cards}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
