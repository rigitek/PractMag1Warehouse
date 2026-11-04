using System;
using System.Collections.Generic;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class Storage_Strategy
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public string rulesJson { get; set; }
        public string description { get; set; }
    }
}
