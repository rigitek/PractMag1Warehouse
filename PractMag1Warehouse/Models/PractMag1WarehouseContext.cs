using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PractMag1Warehouse.Models
{
    public class PractMag1WarehouseContext:DbContext
    {
        public DbSet<Demand_Forecast> Demand_Forecasts{ get; set; }
        public DbSet<Inventory> Inventories{ get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<Location> Locations{ get; set; }
        public DbSet<Relocation_Plan> Relocation_Plans{ get; set; }
        public DbSet<Relocation_Task> Relocation_Tasks{ get; set; }
        public DbSet<Storage_Strategy> Storage_Strategies{ get; set; }
        public DbSet<Warehouse> Warehouses{ get; set; }
        public DbSet<Zone> Zones{ get; set; }

        public PractMag1WarehouseContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=warehouse.db");
        }

    }
}
