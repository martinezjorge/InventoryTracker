using SQLite;

namespace InventoryTracker
{
    public class Inventory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Product { get; set; }
        public int Actual { get; set; }
        public int Ideal { get; set; }

        public override string ToString()
        {
            return $"{Product} - {Actual} - {Ideal}";
        }
    }
}
