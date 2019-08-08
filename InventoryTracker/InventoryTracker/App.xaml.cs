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

        // behaviour when the program is started
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // populate the instance of the inventory item list on start up
            inventoryList = InventoryList.FillInventoryListFromSQL();
        }

        // behaviour when the program is closed
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            // Writes the data in the dynamic inventory list to the csv whenever the program is closed
            InventoryList.WriteFullInventoryListToCSV(inventoryList);
        }

        // a custom class specific to this project, returns the inventory list whenever called
        internal InventoryList GetInventoryList()
        {
            return inventoryList;
        }
    }
}
