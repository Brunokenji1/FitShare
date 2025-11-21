using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFitShare.Converters
{
    public class BoolToTextRecorrenteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is bool ehRecorrente && ehRecorrente) return "↺ Semanal";
            return "📅 Único";

        }

        public object ConvertBack(object value, Type target, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
