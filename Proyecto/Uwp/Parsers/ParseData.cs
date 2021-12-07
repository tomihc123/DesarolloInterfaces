using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Uwp.Parsers
{
    class ParseData : IValueConverter
    {

        public Object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = (DateTime)value;
            String smallDate = "";

            if (date != null)
            {

                smallDate = date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }

            return smallDate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)

        {
            String smallDate = value as String;
            DateTime date = DateTime.Parse(smallDate);
            return date;
        }


    }
}
