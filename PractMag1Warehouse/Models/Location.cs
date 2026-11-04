using System;
using System.Collections.Generic;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class Location
    {
        public int id { get; set; }
        public string coordinates { get; set; }
        public string status { get; set; }
        public float maxWeight { get; set; }
        public int zoneId { get; set; }
        public Zone zone { get; set; }
    }
}
