using System;
using System.Collections.Generic;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int CurrentLoad { get; set; }
        public bool IsDynamic { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
