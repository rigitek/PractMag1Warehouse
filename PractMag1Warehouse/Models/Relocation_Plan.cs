using System;
using System.Collections.Generic;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class Relocation_Plan
    {
        public int id { get; set; }
        public DateTime plannedAt { get; set; }
        public string status { get; set; }
        public int strategyId { get; set; }
        public Storage_Strategy strategy { get; set; }
    }
}
