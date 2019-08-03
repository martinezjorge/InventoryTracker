using System.Windows;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Edit_Item_Window.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
        InventoryItem tempInventoryItem = null;
        int itemIndex = -1;
        public EditItem()
        {
            InitializeComponent();
            itemIndex = Global.GetIndex();
            tempInventoryItem = new InventoryItem(inventoryList[itemIndex].ItemName, inventoryList[itemIndex].CurrentStock, inventoryList[itemIndex].IdealStock);
            window_panel.DataContext = tempInventoryItem;
        }
        private void Delete_button(object sender, RoutedEventArgs e)
        {
            inventoryList.RemoveAt(itemIndex);
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Submit_button(object sender, RoutedEventArgs e)
        {
            inventoryList[itemIndex] = tempInventoryItem;
            InventoryList.PercentageFillerSingle(inventoryList, itemIndex);
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Cancel_button(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}