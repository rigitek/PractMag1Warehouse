using System;
using System.Collections.Generic;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class Demand_Forecast
    {
        public int id { get; set; }
        public DateTime periodStart { get; set; }
        public DateTime periodEnd { get; set; }
        public string periodLabel { get; set; }
    }
}
