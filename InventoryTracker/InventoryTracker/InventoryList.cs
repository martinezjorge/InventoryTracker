using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
//using Excel = Microsoft.Office.Interop.Excel;


namespace InventoryTracker
{
    class InventoryList : System.Collections.CollectionBase
    {
        public int Add(InventoryItem value)
        {
            return List.Add(value);
        }
        public InventoryItem this[int index]
        {
            get { return (InventoryItem)List[index]; }
            set { List[index] = value; }
        }

        public static InventoryList FillInventoryListFromCSV()
        {
            InventoryList inList = new InventoryList();
            System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            string gparent = myDirectory.Parent.Parent.FullName;
            gparent += "\\InventoryDatabase.csv";
            var reader = new StreamReader(@gparent);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                inList.Add(new InventoryItem(data[0], Int32.Parse(data[1]), Int32.Parse(data[2])));
            }
            reader.Close();
            PercentageFillerAll(inList);

            return inList;
        }
        /*
        public static InventoryList FillInventoryListFromExcel()
        {
            InventoryList inList = new InventoryList();
            Excel.Application xlapplication = new Excel.Application();
            xlapplication.Visible = false;
            System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            string gparent = myDirectory.Parent.Parent.FullName;
            gparent += "\\InventoryDatabase.xlsx";
            Excel.Workbook xlworkbook = xlapplication.Workbooks.Open(@gparent);
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlworkbook.Sheets[1];
            Excel.Range xlrange = xlworksheet.UsedRange;

            int rowCount = xlrange.Rows.Count;
            int colCount = xlrange.Columns.Count;

            //excel not zero based; skip first row of excel worksheet
            for (int row = 2; row <= rowCount; row++)
            {
                inList.Add(new InventoryItem((String)xlrange.Cells[row, 1].Value2, (int)xlrange.Cells[row, 2].Value2, (int)xlrange.Cells[row, 3].Value2));
            }

            //garbage collection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            xlworkbook.Save();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlrange);
            Marshal.ReleaseComObject(xlworksheet);

            //close and release
            xlworkbook.Close();
            Marshal.ReleaseComObject(xlworkbook);

            //quit and release
            xlapplication.Quit();
            Marshal.ReleaseComObject(xlapplication);

            //fills in the percentages
            PercentageFillerAll(inList);

            return inList;
        }
        */

        public static void PrintInventoryList(InventoryList inList)
        {
            Console.WriteLine("Capacity: {0}", inList.Capacity);
            Console.WriteLine("Count: {0}", inList.Count);

            for (int i = 0; i < inList.Count; i++)
            {
                Console.WriteLine("Item Name: " + inList[i].ItemName + " Current Stock: " + inList[i].CurrentStock + " Ideal Stock: " + inList[i].IdealStock);
            }
        }

        public static void FillAdditionalSampleItems(InventoryList inList)
        {
            inList.Add(new InventoryItem("Computer", 3, 5));
            inList.Add(new InventoryItem("Monitor", 2, 3));
            inList.Add(new InventoryItem("Keyboard", 3, 4));
        }

        public static void PercentageFillerAll(InventoryList inList)
        {
            for(int i = 0; i < inList.Count; i++)
            {
                PercentageFillerSingle(inList, i);
            }
        }
        public static void PercentageFillerSingle(InventoryList inList, int i)
        {
            inList[i].Percentage = 100 * inList[i].CurrentStock / inList[i].IdealStock;
        }

        public static void WriteFullInventoryListToCSV(InventoryList inList)
        {
            System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            string gparent = myDirectory.Parent.Parent.FullName;
            gparent += "\\InventoryDatabase.csv";
            var writer = new StreamWriter(@gparent);

            for (int i = 0; i < inList.Count; i++)
            {
                writer.WriteLine(string.Format("{0},{1},{2}", inList[i].ItemName, inList[i].CurrentStock, inList[i].IdealStock));
                writer.Flush();
            }
            writer.Close();
        }

        /*
        public static void WriteInventoryListToExcel(InventoryList inList)
        {
            Excel.Application xlapplication = new Excel.Application();
            xlapplication.Visible = false;
            System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            string gparent = myDirectory.Parent.Parent.FullName;
            gparent += "\\InventoryDatabase.xlsx";
            Excel.Workbook xlworkbook = xlapplication.Workbooks.Open(@gparent);
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlworkbook.Sheets[1];
            Excel.Range xlrange = xlworksheet.UsedRange;
            int row = 2;

            for (int i = 0; i < inList.Count; i++)
            {
                xlworksheet.Cells[row, 1] = inList[i].ItemName;
                xlworksheet.Cells[row, 2] = inList[i].CurrentStock;
                xlworksheet.Cells[row, 3] = inList[i].IdealStock;
                row += 1;
            }

            //garbage collection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            xlworkbook.Save();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlrange);
            Marshal.ReleaseComObject(xlworksheet);

            //close and release
            xlworkbook.Close();
            Marshal.ReleaseComObject(xlworkbook);

            //quit and release
            xlapplication.Quit();
            Marshal.ReleaseComObject(xlapplication);
        }
        */
    }
}
