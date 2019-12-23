using ShoppingServer.Model;
using ShoppingServer.Model.response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingServer.Model.tableModel;

namespace ShoppingServer.Bll
{
    public class MainBll
    {
        DataContext _db;

        public MainBll(DataContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <returns></returns>
        public List<CommodityModel> GetCommodityList()
        {
            var result = new List<CommodityModel>();
            var list = _db.CommodityEntity.Where(t => t.RowStatus == 1).OrderByDescending(t => t.CreateDate).ToList();
            if (list.Any())
            {
                list.ForEach(t =>
                {
                    result.Add(new CommodityModel
                    {
                        Id = t.Id.ToString(),
                        Title = t.Title,
                        ImgUrl = t.ImgUrl,
                        Price = t.Price.ToString(),
                        Stock = t.Sale == t.Total ? "已售罄" : "剩：" + t.Sale.ToString() + "/" + t.Total.ToString()
                    }); ;
                });
            }
            return result;
        }

        public BaseResponse AddCommondity(CommodityModel model)
        {
            var result = new BaseResponse();
            _db.Add(new CommodityEntity
            {
                Title = model.Title,
                Describe = model.Describe,
                Total = Convert.ToInt32(model.Total),
                Price = Convert.ToDecimal(model.Price),
                SalePrice = Convert.ToDecimal(model.SalePrice),
                ImgUrl = model.ImgUrl
            });
            _db.SaveChanges();
            return result;
        }
    }
}
