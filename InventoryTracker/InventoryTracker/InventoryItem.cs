using System;

namespace InventoryTracker
{
    class InventoryItem
    {
        String itemName;
        int currentStock;
        int idealStock;
        int percentage;

        public InventoryItem(String name, int cStock, int iStock)
        {
            itemName = name;
            currentStock = cStock;
            idealStock = iStock;
        }

        public String ItemName { get => itemName; set => itemName = value; }

        public int CurrentStock { get => currentStock; set => currentStock = value; }

        public int IdealStock { get => idealStock; set => idealStock = value; }

        public int Percentage { get => percentage; set => percentage = value; }
    }
}