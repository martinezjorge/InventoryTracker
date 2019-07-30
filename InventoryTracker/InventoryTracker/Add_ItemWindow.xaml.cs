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
    /// Interaction logic for Window2.xaml
    /// </summary>
    
    public partial class Window2 : Window
    {

        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
        InventoryItem tempInventoryItem = null;
        int itemIndex = -1;

        public Window2()
        {
            InitializeComponent();
            itemIndex = Global.GetIndex();
            tempInventoryItem = new InventoryItem("Insert Item Name", 0, 0);
            AddItemPanel.DataContext = tempInventoryItem;
        }

        private void Submit_Add_Button(object sender, RoutedEventArgs e)
        {
            inventoryList.Add(tempInventoryItem);
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
