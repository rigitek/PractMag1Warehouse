using System;
using System.Collections.Generic;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public float weight { get; set; }
        public float turnoverRate { get; set; }
        public int shelfLife { get; set; }
    }
}
