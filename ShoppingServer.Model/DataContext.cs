using Microsoft.EntityFrameworkCore;
using ShoppingServer.Model.tableModel;
using System;

namespace ShoppingServer.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<CommodityEntity> CommodityEntity { get; set; }
    }
}
