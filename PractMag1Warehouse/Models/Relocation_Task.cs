using System;
using System.Collections.Generic;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class Relocation_Task
    {
        public int id {  get; set; }
        public int priority { get; set; }
        public string status { get; set; }
        public DateTime startedAt { get; set; }
        public DateTime completedAt { get; set; }
        public int planId { get; set; }
        public Relocation_Plan plan { get; set; }
        public int itemId { get; set; }
        public Item item { get; set; }
        public int fromLocationId { get; set; }
        public Location fromLocation { get; set; }
        public int toLocationId { get; set; }
        public Location toLocation { get; set; }
    }
}
