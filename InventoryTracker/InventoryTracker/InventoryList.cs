using System;
using System.IO;
using SQLite;

namespace InventoryTracker
{
    class InventoryList : System.Collections.CollectionBase
    {

        public static InventoryList FillInventoryListFromSQL()
        {

            // creates an inventory list object
            InventoryList inList = new InventoryList();

            // sql reader object to get all the rows from the query
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Inventory>();

                foreach( Inventory item in conn.Table<Inventory>().ToList())
                {
                    inList.Add(new InventoryItem(item.Product, item.Actual, item.Ideal));
                }
            }

            // calculate the stock percentages for all the items in the inventory list
            PercentageFillerAll(inList);
            
            // Sorts by the item name!
            SortByItemName(inList);

            return inList;

        }

        // method to add an item to the end of the inventory list
        public int Add(InventoryItem value)
        {
            return List.Add(value);
        }

        // returns the inventory item at the given index in the inventory list
        public InventoryItem this[int index]
        {
            // gets the index of the current inventory item
            get { return (InventoryItem)List[index]; }
            // sets the value in the current index in the inventory item
            set { List[index] = value; }
        }

        // returns the index of the inventory item in the inventory list
        public int this[InventoryItem inItem]
        {
            get { return List.IndexOf((InventoryItem)inItem); }
        }

        //this sorts the inventorylist in descending item name
        public static void SortByItemName(InventoryList inList)
        {
            inList.InnerList.Sort(new myComparer());
        }

        // Method to run the percentage fill single method on all the inventorylist rows
        public static void PercentageFillerAll(InventoryList inList)
        {
            // goes through every row in the inventory list
            for (int i = 0; i < inList.Count; i++)
            {
                // calclulates the perfect
                PercentageFillerSingle(inList, i);
            }
        }

        // calculates the percentage for a given inventory item stock
        public static void PercentageFillerSingle(InventoryList inList, int i)
        {
            // calculates the percentage
            inList[i].Percentage = 100 * inList[i].CurrentStock / inList[i].IdealStock;
        }

    }
}