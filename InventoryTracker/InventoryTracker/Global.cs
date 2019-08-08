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
        // default value that isn't in range
        private static int index = -1; 
        
        // Setter method for the global item index
        internal static void SetIndex(int value)
        {
            index = value;
        }
        // getter method for the gloval item index
        internal static int GetIndex()
        {
            return index;
        }

        internal static bool IsValid(String Name, String CurrentStock, String IdealStock)
        {
            //gets the inventorylist to be used for checking for duplications
            InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
            
            // *********data validation*******************//
            bool valid = true;
            bool isNumeric;


            // If length of the item length is greater than 40 or less than 1 its not valid
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
            
            //not valid if idealstock is 0
            if (valid)
            {
                if (Int32.Parse(IdealStock) == 0)
                {
                    valid = false;
                }
            }

            // checking if item will be a duplicate
            for(int i = 0; i < inventoryList.Count; i++)
            {
                //if (Name.Equals(inventoryList[i].ItemName)){ //exact matching
                //case insensitive check for duplicates
                if (string.Compare(inventoryList[i].ItemName, Name, StringComparison.OrdinalIgnoreCase) == 0) { 
                    valid = false;
                }
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
