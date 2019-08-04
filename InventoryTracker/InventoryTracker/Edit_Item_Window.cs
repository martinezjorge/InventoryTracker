using System.Windows;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Edit_Item_Window.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        // this appears to get whatever is loaded in the inventory list in dynamic memory
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
        // Creates a new inventory item to hold the new row of data we wish to modify
        InventoryItem tempInventoryItem = null;

        // temporarily sets the index to a moot value
        // have to do this because C# doesn't allow you declare a variable without initializing it
        int itemIndex = -1;

    
        // Edit Item Window Constructor
        public EditItem()
        {
            // Starts up the window
            InitializeComponent();
            // gets the index of the row in the inventory list that we wish to edit
            itemIndex = Global.GetIndex();
            // creates a temp inventory item to hold the values from the main window that we wish to edit
            tempInventoryItem = new InventoryItem(inventoryList[itemIndex].ItemName, inventoryList[itemIndex].CurrentStock, inventoryList[itemIndex].IdealStock);
            // populates the edit item window with the data from the selected row
            window_panel.DataContext = tempInventoryItem;
        }
        private void Delete_button(object sender, RoutedEventArgs e)
        {
            // removes the selected row from the inventory window given the global 
            inventoryList.RemoveAt(itemIndex);
            // Creates a new instance of the main window
            Window mainWindow = new MainWindow();
            // Shows the new instance of the main window
            mainWindow.Show();
            // Closes the edit item window
            this.Close();
        }

        // logic for pushing any changes through to the inventory list
        private void Submit_button(object sender, RoutedEventArgs e)
        {
            /*
                 Data Validation on the text boxes

                     true => modify file
                     false => invalidEntry window
            */

            // checks all the fields in the textboxes using validation inside of the global class
            if(Global.IsValid(EditItemNameBox.Text, EditItemCurrentStockBox.Text, EditItemIdealStockBox.Text))
            {
                // replaces the row with in the inventory list with the modified inventory item using the global itemIndex
                inventoryList[itemIndex] = tempInventoryItem;
                // calclulates the percentage by sending the inventorylist and index of the row
                InventoryList.PercentageFillerSingle(inventoryList, itemIndex);
                // creates a new instance of the main window
                Window mainWindow = new MainWindow();
                // shows the new instance of the main window
                mainWindow.Show();
                // closes the instance of the edit item window
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
        
        // if the user decides not to make any changes
        private void Cancel_button(object sender, RoutedEventArgs e)
        {
            // creates a new instance of the main window
            Window mainWindow = new MainWindow();
            // makes the instance visible
            mainWindow.Show();
            // closes the instance of the edit item window
            this.Close();
        }
    }
}