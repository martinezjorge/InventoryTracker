using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Taken from https://www.csharp-console-examples.com/arrays/c-program-to-sort-arraylist-of-custom-objects-by-property/
 * Referenced website in SRS document. In addition, website does not state what licensing is applicable to the taken code
 */

namespace InventoryTracker
{
    //this is used for the sorting by item name function in the inventorylist.cs
    public class myComparer : IComparer
    {
        int IComparer.Compare(Object xx, Object yy)
        {
            InventoryItem x = (InventoryItem)xx;
            InventoryItem y = (InventoryItem)yy;
            return x.ItemName.CompareTo(y.ItemName);
        }
    }
}
