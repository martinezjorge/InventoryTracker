/* Inventory Tracker - Team Mithrandir */

// Jorge Martinez
// Nathan Ray
// Ben Stanke
// Marcial Mendoza
// Leslie Ledeboer

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Main_Window.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        // gets the most recent version of the inventory list in memory
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();

        // Main Windor Interface Constructor
        public MainWindow()
        {
            // Opens the main window
            InitializeComponent();
            // Loads the inventory list from the csv file
            InventoryListing.DataContext = inventoryList;
        }

        // logic for the edit button
        private void Edit_Button(object sender, RoutedEventArgs e)
        {
            // int index = InventoryListing.SelectedIndex
            // this gets the row # (starts at 0 for top of list)
            // Sets a global variable to the index of the selected row
            //Global.SetIndex(InventoryListing.SelectedIndex);
            //Global.SetReferencedInventoryItem((InventoryItem)InventoryListing.SelectedItem);
            Global.SetIndex(inventoryList[(InventoryItem)InventoryListing.SelectedItem]);
            // Creates an instance of the edit item window
            Window editItemWindow = new EditItem();
            // Makes the instance visible
            editItemWindow.Show();
            // Closes the current instance of the main window
            this.Close();
        }

        // logic for the add item button
        private void Add_Item_Button(object sender, RoutedEventArgs e)
        {
            // creates an instances of the add item window
            Window addItemWindow = new AddItem();
            // shows the instance of the add item window
            addItemWindow.Show();
            // closes the main window
            this.Close();
        }

        // logic for the full inventory button
        private void Full_Inventory_Button(object sender, RoutedEventArgs e)
        {
            // Sets the global index to 0 so it can start at the beginning of the list
            Global.SetIndex(0); 
            // Creates an instance of the iterative update window
            Window iterativeUpdateWindow = new Iterative_Update_Window();
            // Shows the instance of the iterative update window
            iterativeUpdateWindow.Show();
            // Closes the main window
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // gets search box contents                     
            string searchBoxContents = SearchBox.Text;
            // gets the item index of the searched for item
            int wantedItemIndex = Global.InventoryListSearch(searchBoxContents);

            // if there isn't a match, open an invalid entry window
            if (wantedItemIndex == -1)
            {
                Window invalidEntry = new InvalidEntry();
                invalidEntry.Show();
            }
            // open the edit item window
            else
            {
                // Creates an instance of the edit item window
                Window editItemWindow = new EditItem();
                // Makes the instance visible
                editItemWindow.Show();
                // Closes the current instance of the main window
                this.Close();
            }
        }

        private void TextBox_KeyEnterUpdate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                TextBox tBox = (TextBox)sender;

                DependencyProperty prop = TextBox.TextProperty;

                BindingExpression binding = BindingOperations.GetBindingExpression(tBox, prop);

                if (binding != null)
                    SearchButton_Click(sender, e);
            }
        }

    }
}