using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SchoolApp.AppFiles
{
    public class DateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateValue = (DateTime)value;
            DateTime currentDate = DateTime.Now;

            TimeSpan timeUntilExpiration = dateValue - currentDate;

            if (timeUntilExpiration.Days <= 3)
            {
                return Brushes.PaleVioletRed;
            }
            else if (timeUntilExpiration.Days <= 7 && timeUntilExpiration.Days>3)
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.LightGreen;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
