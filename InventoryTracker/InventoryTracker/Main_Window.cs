/* Inventory Tracker - Team Mithrandir */

// Jorge Martinez
// Nathan Ray
// Ben Stanke
// Marcial Mendoza
// Leslie Ledeboer

using System.Windows;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Main_Window.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        // the inventoryList exists outside MainWindow so that it can be affected by the buttons
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();

        public MainWindow()
        {
            InitializeComponent();
            InventoryListing.DataContext = inventoryList;
        }

        private void Edit_Button(object sender, RoutedEventArgs e)
        {
            // int index = InventoryListing.SelectedIndex
            // this gets the row # (starts at 0 for top of list)
            Global.SetIndex(InventoryListing.SelectedIndex);
            Window editItemWindow = new EditItem();
            editItemWindow.Show();
            this.Close();
        }

        private void Add_Item_Button(object sender, RoutedEventArgs e)
        {
            Global.SetIndex(InventoryListing.SelectedIndex);
            Window addItemWindow = new AddItem();
            addItemWindow.Show();
            this.Close();
        }

        private void Full_Inventory_Button(object sender, RoutedEventArgs e)
        {
            Global.SetIndex(0); // starts at beginning of list
            Window iterativeUpdateWindow = new Iterative_Update_Window();
            iterativeUpdateWindow.Show();
            this.Close();
        }
    }
}