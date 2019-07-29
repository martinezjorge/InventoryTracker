using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static InventoryList inventoryList = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //inventoryList = InventoryList.FillInventoryListFromExcel();
            inventoryList = InventoryList.FillInventoryListFromCSV();
        }

        internal InventoryList GetInventoryList()
        {
            return inventoryList;
        }
    }
}
