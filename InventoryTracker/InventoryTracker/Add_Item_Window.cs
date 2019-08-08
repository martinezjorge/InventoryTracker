using System.Windows;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System;
using System.Data;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Add_Item_Window.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        // gets the inventory list stored in dynamic memory
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
        // creates a temporary inventory item to have everything added to
        InventoryItem tempInventoryItem = null;
        // creates a variable to hold the row index; might not be necessary since we just add it to the end of the list
        int itemIndex = -1;

        // Add Item Window Constructor
        public AddItem()
        {
            // Opens the add item window
            InitializeComponent();
            // grabs the index of the row from global; never used
            itemIndex = Global.GetIndex();
            // Creates temporary data to populate the add item interface
            tempInventoryItem = new InventoryItem("", 0, 0);
            // Populates the add item interface
            window_panel.DataContext = tempInventoryItem;
        }

        private void Submit_Add_Button(object sender, RoutedEventArgs e)
        {
            /*
             
                 Data Validation on the text boxes

                     true => add item
                     false => invalidEntry window

            */

            // Database connection
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoginDB; Integrated Security=True;");
            try
            {

                if (Global.IsValid(AddItemNameBox.Text, AddItemCurrentStockBox.Text, AddItemIdealStockBox.Text))
                {
                    // If the connection is closed
                    if (sqlCon.State == ConnectionState.Closed)
                        // Open it!
                        sqlCon.Open();

                    // SQL Query with @placeholders for later bindings
                    // INSERT [dbo].[StudentGrade] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (1, N'C1045', 1, CAST(3.50 AS Decimal(3, 2)))
                    String query = "INSERT [dbo].[tblInventory] ([Product],[Actual],[Ideal]) VALUES (@Product, @Actual, @Ideal)";
                    // Prepare the command with the query and db connection
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    // I guess it has know that its a text command
                    sqlCmd.CommandType = CommandType.Text;
                    // Bind product name user wrote into the textbox
                    sqlCmd.Parameters.AddWithValue("@Product", AddItemNameBox.Text);
                    // Bind the actual user wrote into the textbox
                    sqlCmd.Parameters.AddWithValue("@Actual", AddItemCurrentStockBox.Text);
                    // Bind the ideal user wrote into the textbox
                    sqlCmd.Parameters.AddWithValue("@Ideal", AddItemIdealStockBox.Text);
                    // Insert into database
                    sqlCmd.ExecuteNonQuery();

                    // Uses add method from inventoryList class to add the data in textboxes to inventory list
                    inventoryList.Add(tempInventoryItem);
                    // Calculates the percentage for the new item added to the inventory
                    InventoryList.PercentageFillerSingle(inventoryList, inventoryList.Count - 1);
                    // Creates a new instance of the main window
                    Window mainWindow = new MainWindow();
                    // Shows the new instance of the main window
                    mainWindow.Show();
                    // Closes the instance of the add item window
                    this.Close();
                }
                else
                {
                    // create an instance of the invalid entry window
                    Window invalidEntry = new InvalidEntry();
                    // show it, however the edit item window is not closed
                    invalidEntry.Show();
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


        }
        private void Submit_Cancel_Button(object sender, RoutedEventArgs e)
        {
            // Creates a new instance of the main window
            Window mainWindow = new MainWindow();
            // Shows the new instance of the main window
            mainWindow.Show();
            // Closes the instance of the add item window
            this.Close();
        }

        // uses regular expressions to ensure nonintegers cannot be entered into integer text fields
        private void IntegerValidation(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}