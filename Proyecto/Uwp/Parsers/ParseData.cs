using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Uwp.Parsers
{
    class ParseData : IValueConverter
    {

        /// <summary>
        /// Convierte a fecha
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Convierte a fecha
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)

        {

            DateTime dateTime = new DateTime();

            try
            {
                String smallDate = value as String;
                dateTime = DateTime.Parse(smallDate);

            } catch(Exception)
            {
             

              }
      
               return dateTime;       

        }


    }
}
