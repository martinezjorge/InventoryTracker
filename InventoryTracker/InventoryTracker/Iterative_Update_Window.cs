using System.Windows;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Iterative_Update_Window.xaml
    /// </summary>
    public partial class Iterative_Update_Window : Window
    {
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
        InventoryItem tempInventoryItem = null;
        int itemIndex = -1;
        public Iterative_Update_Window()
        {
            InitializeComponent();
            itemIndex = Global.GetIndex();
            tempInventoryItem = new InventoryItem(inventoryList[itemIndex].ItemName, inventoryList[itemIndex].CurrentStock, inventoryList[itemIndex].IdealStock);
            window_panel.DataContext = tempInventoryItem;
        }
        private void Update_Next(object sender, RoutedEventArgs e)
        {
            inventoryList[itemIndex] = tempInventoryItem;
            InventoryList.PercentageFillerSingle(inventoryList, itemIndex);
            itemIndex++; // essentially i++

            if (itemIndex > inventoryList.Count - 1) // greater than total number of items in list, then at end of list
            {
                Global.SetIndex(-1); // reset the global item index
                Window mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

            else
            {
                Global.SetIndex(itemIndex);
                Window iterativeUpdateWindow = new Iterative_Update_Window();
                iterativeUpdateWindow.Show();
                this.Close();
            }
        }
        private void Update_Home(object sender, RoutedEventArgs e)
        {
            inventoryList[itemIndex] = tempInventoryItem;
            InventoryList.PercentageFillerSingle(inventoryList, itemIndex);
            Global.SetIndex(-1); // reset the global item index
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Global.SetIndex(-1);
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}