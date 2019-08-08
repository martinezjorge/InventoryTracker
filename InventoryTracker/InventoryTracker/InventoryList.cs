using System;
using System.IO;
using System.Data.SqlClient;    // local DB
using System.Windows;

namespace InventoryTracker
{
    class InventoryList : System.Collections.CollectionBase
    {
        // Static method to fill inventory list using a sql db query
        public static InventoryList FillInventoryListFromSQL()
        {
            // Database connection
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoginDB; Integrated Security=True;");
            // creates an inventory list object
            InventoryList inList = new InventoryList();

            try
            {
                // If the connection is closed
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    // Open it!
                    sqlCon.Open();
                // SQL Query with @placeholders for later bindings
                String query = "SELECT * FROM tblInventory";

                // Prepare the command with the query and db connection
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                // sql reader object to get all the rows from the query
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    // While there are rows
                    while (reader.Read())
                        // Store sql row into an inventory item and add it to the inventory list
                        inList.Add(new InventoryItem(String.Format("{0}", reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
                }

            }
            catch (Exception ex)
            {
                // If theres an error this will throw the error message
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Always closes the db connection regardless of success or failure
                sqlCon.Close();
            }

            // calculate the stock percentages for all the items in the inventory list
            PercentageFillerAll(inList);

            return inList;
        }


        // static method to fill inventory list from csv
        public static InventoryList FillInventoryListFromCSV()
        {
            // creates an inventory list object
            InventoryList inList = new InventoryList();
            // creates an directory path object
            System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            // finds the path to the folder the csv file is in
            string gparent = myDirectory.Parent.Parent.FullName;
            // concats the name of the file to the path
            gparent += "\\InventoryDatabase.csv";
            // creates a file object to read the csv file
            var reader = new StreamReader(@gparent);

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

            // return the inventory list
            return inList;
        }

        // method to write everything in the inventory list object to a csv
        public static void WriteFullInventoryListToCSV(InventoryList inList)
        {
            // creates a directory path object
            System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            // stores the path to the folder the csv file is in in a string
            string gparent = myDirectory.Parent.Parent.FullName;
            // concats the file name to the pathname
            gparent += "\\InventoryDatabase.csv";
            // creates a file writer object to write to the csv file; this method overwrites the file
            var writer = new StreamWriter(@gparent);

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

        // method to add an item to the end of the inventory list
        public int Add(InventoryItem value)
        {
            return List.Add(value);
        }

        // returns this index of the inventory item in the inventory list
        public InventoryItem this[int index]
        {
            // gets the index of the current inventory item
            get { return (InventoryItem)List[index]; }
            // sets the value in the current index in the inventory item
            set { List[index] = value; }
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


        // Currently not used
        public static void PrintInventoryList(InventoryList inList)
        {
            Console.WriteLine("Capacity: {0}", inList.Capacity);
            Console.WriteLine("Count: {0}", inList.Count);

            for (int i = 0; i < inList.Count; i++)
            {
                Console.WriteLine("Item Name: " + inList[i].ItemName + " Current Stock: " + inList[i].CurrentStock + " Ideal Stock: " + inList[i].IdealStock);
            }
        }

        // Currently not used
        public static void FillAdditionalSampleItems(InventoryList inList)
        {
            inList.Add(new InventoryItem("Computer", 3, 5));
            inList.Add(new InventoryItem("Monitor", 2, 3));
            inList.Add(new InventoryItem("Keyboard", 3, 4));
        }

    }
}