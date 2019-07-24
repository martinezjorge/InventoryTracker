using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker
{
    public class Person
    {
        //private string v1;
        //private string v2;
        //private string v3;
        //private string v4;

        public string V1 { get; set; }
        public string V2 { get; set; }
        public string V3 { get; set; }
        public string V4 { get; set; }

        //public Person(string firstName, string lastName, int id, string email)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    ID = id;
        //    Email = email;
        //}

        public Person(string v1, string v2, string v3, string v4)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.V3 = v3;
            this.V4 = v4;
        }
    }
}
