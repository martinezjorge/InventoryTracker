using System.Windows;
using System.Text.RegularExpressions;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Iterative_Update_Window.xaml
    /// </summary>
    public partial class Iterative_Update_Window : Window
    {
        // Gets whatever state the inventory list is from dynamic memory
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
        // temp inventory item is created to work with
        InventoryItem tempInventoryItem = null;
        // item index variable is created to keep track of where we are in the iterative update
        int itemIndex = -1;

        // Iterative Update Window Constructor
        public Iterative_Update_Window()
        {
            // Initialize the component
            InitializeComponent();
            // Gets the index from global which should be set to 0 from Main_Window.cs
            itemIndex = Global.GetIndex();
            // Sets inventory item to the data from the first row
            tempInventoryItem = new InventoryItem(inventoryList[itemIndex].ItemName, inventoryList[itemIndex].CurrentStock, inventoryList[itemIndex].IdealStock);
            // Populates the interface with the inventory item
            window_panel.DataContext = tempInventoryItem;
        }
        private void Update_Next(object sender, RoutedEventArgs e)
        {
            // Stores the inventory 
            inventoryList[itemIndex] = tempInventoryItem;
            InventoryList.PercentageFillerSingle(inventoryList, itemIndex);
            // Increments to the next item in the inventory list
            itemIndex++;

            // If we're at the end of the inventory list
            if (itemIndex > inventoryList.Count - 1) // greater than total number of items in list, then at end of list
            {
                // reset the global item index
                Global.SetIndex(-1); 
                // create a new instance of the main window
                Window mainWindow = new MainWindow();
                // show the instance of the main window
                mainWindow.Show();
                // close the full iterative update window
                this.Close();
            }
            // if we're not at the end yet
            else
            {
                // set the global item index to the incremented index
                Global.SetIndex(itemIndex);
                // create a new instance of the iterative update window
                Window iterativeUpdateWindow = new Iterative_Update_Window();
                // show the instance of the iterative update window
                iterativeUpdateWindow.Show();
                // close the previous instance of the iterative update window
                this.Close();
            }
        }
        private void Update_Home(object sender, RoutedEventArgs e)
        {
            // Update the inventory list with the new stock
            inventoryList[itemIndex] = tempInventoryItem;
            // Calculate the new percentage based on the new stock
            InventoryList.PercentageFillerSingle(inventoryList, itemIndex);
            // reset the global item index
            Global.SetIndex(-1); 
            // create a new instance of the main window
            Window mainWindow = new MainWindow();
            // Show the new instance of the main window
            mainWindow.Show();
            // Close the instance of the iterative update window
            this.Close();
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            // Reset the global item index
            Global.SetIndex(-1);
            // Create a new instance of the main window
            Window mainWindow = new MainWindow();
            // Show the new instance of the main window
            mainWindow.Show();
            // Close the instance of the interative update window
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