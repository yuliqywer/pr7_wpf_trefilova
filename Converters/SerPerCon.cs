using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pr7_trefilova.Converters
{
    public class SerPerCon :IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            if (value is float f) return System.Convert.ToInt32(f * 100);
            if (float.TryParse(value.ToString( ), NumberStyles.Float, culture, out float result))
                return result * 100;
            return string.Empty;
        }

        public object ConvertBack (object value, Type targetType, object parametr, CultureInfo culture)
        {
            if (value == null) return null;
            if (float.TryParse(value.ToString( ), NumberStyles.Float, culture, out float result))
                return result / 100f;

            return null;
        }
    }
}
