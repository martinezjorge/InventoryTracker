using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker
{
    public class Global
    {
        private static int index = -1; // default value that isn't in range
        
        internal static void SetIndex(int value)
        {
            index = value;
        }
        internal static int GetIndex()
        {
            return index;
        }
    }
}
