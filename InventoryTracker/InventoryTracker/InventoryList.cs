using System;
using System.IO;

namespace InventoryTracker
{
    class InventoryList : System.Collections.CollectionBase
    {
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
        
        // static method to fill inventory list from csv
        public static InventoryList FillInventoryListFromCSV()
        {
            // creates an inventory list object
            InventoryList inList = new InventoryList();
            // creates an directory path object
            //System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            // finds the path to the folder the csv file is in
            //string gparent = myDirectory.Parent.Parent.FullName;
            // concats the name of the file to the path
            //gparent += "\\InventoryDatabase.csv";
            // creates a file object to read the csv file
            //var reader = new StreamReader(@gparent);
            var reader = new StreamReader(@"InventoryDatabase.csv");

            // while not the end of file
            while (!reader.EndOfStream)
            {
                // read the line
                string line = reader.ReadLine();
                // split by comma
                string[] data = line.Split(',');
                // add the row to the inventory list object
                inList.Add(new InventoryItem(data[0], Int32.Parse(data[1]), Int32.Parse(data[2])));
            }
            // close the file object
            reader.Close();
            // calculate the stock percentages for all the items in the inventory list
            PercentageFillerAll(inList);

            SortByItemName(inList);
            // return the inventory list
            return inList;
        }

        // method to write everything in the inventory list object to a csv
        public static void WriteFullInventoryListToCSV(InventoryList inList)
        {
            // creates a directory path object
            //System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            // stores the path to the folder the csv file is in in a string
            //string gparent = myDirectory.Parent.Parent.FullName;
            // concats the file name to the pathname
            //gparent += "\\InventoryDatabase.csv";
            // creates a file writer object to write to the csv file; this method overwrites the file
            //var writer = new StreamWriter(@gparent);
            var writer = new StreamWriter(@"InventoryDatabase.csv");

            // goes through every inventory item in the inventory list
            for (int i = 0; i < inList.Count; i++)
            {
                // writes a row to the csv file
                writer.WriteLine(string.Format("{0},{1},{2}", inList[i].ItemName, inList[i].CurrentStock, inList[i].IdealStock));
                // clears the buffer
                writer.Flush();
            }
            // closes the file writer object
            writer.Close();
        }

        
    }
}