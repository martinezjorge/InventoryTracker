using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryTracker
{
    public class Global
    {
        private static int index = -1; // default value that isn't in range
        
        internal static void SetIndex(int value)
        {
            index = value;
        }
        internal static int GetIndex()
        {
            return index;
        }

        internal static bool IsValid(String Name, String CurrentStock, String IdealStock)
        {
            // *********data validation*******************//
            bool valid = true;
            bool isNumeric;


            // item name should be reasonable length
            if (Name.Length > 40 || Name.Length < 1)
            {
                valid = false;
            }

            // not valid if not a number
            isNumeric = int.TryParse(CurrentStock, out _);
            if (!isNumeric)
            {
                valid = false;
            }

            isNumeric = int.TryParse(IdealStock, out _);
            if (!isNumeric)
            {
                valid = false;
            }
            

            // if not valid then InvalidEntry popup window
            if (!valid)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
