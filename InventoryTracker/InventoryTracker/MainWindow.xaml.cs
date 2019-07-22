/* Team Mithrandir */

// Jorge Martinez
// Nathan Ray
// Marcial Mendoza

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        InventoryList inventoryList = InventoryList.FillInventoryListFromExcel();
        public MainWindow()
        {
            InitializeComponent();
            InventoryListing.DataContext = inventoryList;
        }
        private void Edit_Button(object sender, RoutedEventArgs e)
        {
            ;
        }
        private void Add_Item_Button(object sender, RoutedEventArgs e)
        {
            ;
        }
        private void Full_Inventory_Button(object sender, RoutedEventArgs e)
        {
            ;
        }
    }
}
