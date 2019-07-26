/* Team Mithrandir */

// Jorge Martinez
// Nathan Ray
// Ben Stanke
// Marcial Mendoza

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //the inventorylist exists outside mainwindow so that it can be affected by the buttons
        InventoryList inventoryList = ((App)Application.Current).GetInventoryList();
        public MainWindow()
        {
            InitializeComponent();
            InventoryListing.DataContext = inventoryList;
        }
        private void Edit_Button(object sender, RoutedEventArgs e)
        {
            //int index = InventoryListing.SelectedIndex; //this gets the row #. Starts at 0 for top of list
            Global.SetIndex(InventoryListing.SelectedIndex);
            Window editItemWindow = new Edit_ItemWindow();
            editItemWindow.Show();
            this.Close();
        }
        private void Add_Item_Button(object sender, RoutedEventArgs e)
        {
            ;
            //test methods for myself - nathan. feel free to delete
            //InventoryList.FillAdditionalSampleItems(inventoryList);
            //InventoryList.PercentageFillerAll(inventoryList);
        }
        private void Full_Inventory_Button(object sender, RoutedEventArgs e)
        {
            ;
            //test methods for myself - nathan. feel free to delete
            //Window invalidEntry = new InvalidEntry();
            //invalidEntry.Show();
            //this.Close();
        }
    }
}
