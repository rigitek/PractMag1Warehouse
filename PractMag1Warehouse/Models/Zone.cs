using System;
using System.Collections.Generic;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class Zone
    {
        public int id { get; set; }
        public string type { get; set; }
        public int capacity { get; set; }
        public int currentLoad { get; set; }
        public bool isDynamic { get; set; }
        public int warehouseId { get; set; }
        public Warehouse warehouse { get; set; }
    }
}
