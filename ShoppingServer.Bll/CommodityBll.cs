using ShoppingServer.Model;
using ShoppingServer.Model.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingServer.Bll
{
    public class CommodityBll
    {
        DataContext _db;

        public CommodityBll(DataContext dbContext)
        {
            _db = dbContext;
        }
        public CommodityModel GetCommodity(long id)
        {
            var entity = _db.CommodityEntity.Where(t =>t.Id ==id && t.RowStatus == 1).FirstOrDefault();
            var result = new CommodityModel()
            {
                Id = entity.Id.ToString(),
                Title = entity.Title,
                ImgUrl = entity.ImgUrl,
                Price = entity.Price.ToString(),
                SalePrice = entity.SalePrice.ToString(),
                Stock = entity.Sale == entity.Total ? "已售罄" : "剩：" + entity.Sale.ToString() + "/" + entity.Total.ToString(),
                Describe = entity.Describe
            };
            return result;
        }
    }
}
