using System.Windows;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Add_Item_Window.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
        InventoryItem tempInventoryItem = null;
        int itemIndex = -1;
        public AddItem()
        {
            InitializeComponent();
            itemIndex = Global.GetIndex();
            tempInventoryItem = new InventoryItem("Insert Item Name", 0, 0);
            window_panel.DataContext = tempInventoryItem;
        }
        private void Submit_Add_Button(object sender, RoutedEventArgs e)
        {
            inventoryList.Add(tempInventoryItem);
            InventoryList.PercentageFillerSingle(inventoryList, inventoryList.Count - 1);
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Submit_Cancel_Button(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}