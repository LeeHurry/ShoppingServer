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
        public DataContext()
        {
        }
        public DbSet<CommodityEntity> CommodityEntity { get; set; }
        public DbSet<OrderEntity> OrderEntity { get; set; }
        public DbSet<UserInfoEntity> UserInfoEntity { get; set; }
    }
}
