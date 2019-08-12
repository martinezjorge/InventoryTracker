using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace InventoryTracker
{

    class QuantityToForegroundConverter : IValueConverter
    {
        //****************THIS METHOD ANALYZES PERCENTAGE GRID AND SETS APPROPRIATE COLOR*****************//
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Brushes.Transparent; //or null


            if ((int)value <= 25)
            {
                return Brushes.Crimson;
            }
            else if ((int)value <= 50)
            {
                return Brushes.Yellow;
            }
            else
                return Brushes.LightGreen;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
