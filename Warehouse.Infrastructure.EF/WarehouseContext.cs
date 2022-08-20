using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Domain;

namespace Warehouse.Infrastructure.EF
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
        }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}
