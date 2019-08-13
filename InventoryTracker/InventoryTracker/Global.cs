using System;
using System.Windows;

namespace InventoryTracker
{
    public class Global
    {
        // default value that isn't in range
        // this index is used for passing the index reference between windows
        // to refer to the correct item
        private static int index = -1;

        // Setter method for the global item index
        internal static void SetIndex(int value)
        {
            index = value;
        }
        // getter method for the global item index
        internal static int GetIndex()
        {
            return index;
        }

        // default value that isn't in range
        // this index will be used for passing along an error message to the
        // Invalid Entry Window. It will be set via IsValid and thus only
        // gettable, not settable
        private static int errorIndex = -1;

        // getter method for the error index
        internal static int GetErrorIndex()
        {
            return errorIndex;
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
                errorIndex = 0;
            }

            // not valid if not a number
            // if invalid already, skip
            if (valid)
            {
                isNumeric = int.TryParse(CurrentStock, out _);
                if (!isNumeric)
                {
                    valid = false;
                    errorIndex = 1;
                }
            }

            // if invalid already, skip
            if (valid)
            {
                isNumeric = int.TryParse(IdealStock, out _);
                if (!isNumeric)
                {
                    valid = false;
                    errorIndex = 2;
                }
            }

            //not valid if idealstock is 0
            // if invalid already, skip
            if (valid)
            {
                if (Int32.Parse(IdealStock) == 0)
                {
                    valid = false;
                    errorIndex = 3;
                }
            }

            // checking if item will be a duplicate
            // if invalid already, skip
            if (valid)
            {
                for (int i = 0; i < inventoryList.Count; i++)
                {
                    //if (Name.Equals(inventoryList[i].ItemName)){ //exact matching
                    //case insensitive check for duplicates
                    if (i != index)
                    {
                        if (string.Compare(inventoryList[i].ItemName, Name, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            valid = false;
                            errorIndex = 4;
                        }
                    }
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

        //returns the index of the match if match is found, otherwise returns -1
        //if -1 returned, then ensure invalid entry window is opened.
        internal static int InventoryListSearch(String itemName)
        {
            //gets the inventorylist to be used for checking for item name match
            InventoryList inventoryList = ((App)Application.Current).GetInventoryList();

            //sets the index to an out of range value
            index = -1;

            for(int i = 0; i < inventoryList.Count; i++)
            {
                if (string.Compare(inventoryList[i].ItemName, itemName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    //sets the index to match the index of the match
                    index = i;
                }
            }
            
            //if there is no matches, set the errorIndex so that message in invalid entry window
            //reflects no matches
            if (index == -1)
            {
                errorIndex = 5;
            }

            //returns index
            return index;
        }
    }
}
