using System;
using System.Collections.Generic;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class Inventory
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public DateTime lastUpdated { get; set; }
        public int locationId { get; set; }
        public Location location { get; set; }
        public int itemId { get; set;  }
        public Item item { get; set; }
    }
}
