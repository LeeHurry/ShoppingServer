using Microsoft.EntityFrameworkCore;
using ShoppingServer.Model.customModel;
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
        #region TableModel
        public DbSet<CommodityEntity> CommodityEntity { get; set; }
        public DbSet<OrderEntity> OrderEntity { get; set; }
        public DbSet<UserInfoEntity> UserInfoEntity { get; set; }
        #endregion

        #region CustomModel

        public DbSet<OrderInfoModel> OrderInfoModel { get; set; }

        #endregion


    }
}
