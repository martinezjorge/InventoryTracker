using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Edit_ItemWindow.xaml
    /// </summary>
    public partial class Edit_ItemWindow : Window
    {
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
        InventoryItem tempInventoryItem = null;
        int itemIndex = -1;
        public Edit_ItemWindow()
        {
            InitializeComponent();
            itemIndex = Global.GetIndex();
            tempInventoryItem = new InventoryItem(inventoryList[itemIndex].ItemName, inventoryList[itemIndex].CurrentStock, inventoryList[itemIndex].IdealStock);
            EditItemPanel.DataContext = tempInventoryItem;
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
            // data validation on tempInventoryItem
            // true => modify file
            // false => invalidEntry window
            if(Global.IsValid(tempInventoryItem))
            {
                inventoryList[itemIndex] = tempInventoryItem;
                InventoryList.PercentageFillerSingle(inventoryList, itemIndex);
                Window mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                Window invalidEntry = new InvalidEntry();
                invalidEntry.Show();
            }
            
        }

        private void Cancel_button(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }

}
