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
        // creates an instance of inventory list on startup
        static InventoryList inventoryList = null;

        public static string databasePath = "Inventory.db";

        // behaviour when the program is started
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // populate the instance of the inventory item list on start up
            inventoryList = InventoryList.FillInventoryListFromSQL();
        }


        // returns the inventory list whenever called
        internal InventoryList GetInventoryList()
        {
            return inventoryList;
        }
    }
}
