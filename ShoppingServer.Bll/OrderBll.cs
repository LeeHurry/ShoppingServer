using Microsoft.EntityFrameworkCore;
using ShoppingServer.Model;
using ShoppingServer.Model.queryModel;
using ShoppingServer.Model.request;
using ShoppingServer.Model.response;
using ShoppingServer.Model.tableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingServer.Bll
{
    public class OrderBll
    {
        DataContext _db;

        public OrderBll(DataContext dbContext)
        {
            _db = dbContext;
        }

        public BaseResponse CreateOrder(OrderModel model)
        {
            var result = new BaseResponse();
            if (string.IsNullOrEmpty(model.OpenId))
            {
                result.Code = "1001";
                result.Code = "用户未授权，无法获取OpenId";
                return result;
            }
            //用户表是否存在用户
            var userList = _db.UserInfoEntity.Where(t => t.OpenId == model.OpenId);
            if (userList.Any())
            {
                //用户存在
                var user = userList.FirstOrDefault();
                //如果用户修改了昵称，更新用户表昵称
                if (user.NickName != model.NickName)
                {
                    user.NickName = model.NickName;
                    _db.UserInfoEntity.Update(user);
                    _db.SaveChanges();
                }
            }
            else
            {
                //用户不存在
                var user = new UserInfoEntity
                {
                    OpenId = model.OpenId,
                    NickName = model.NickName,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };
                _db.UserInfoEntity.Add(user);
                _db.SaveChanges();
            }
            //获取商品
            var commodity = _db.CommodityEntity.Where(t => t.Id == Convert.ToInt64(model.CommodityId)).FirstOrDefault();

            //创建订单
            var order = new OrderEntity()
            {
                OrderStatus = 1,
                OpenId = model.OpenId,
                CommodityId = Convert.ToInt64(model.CommodityId),
                Count = model.Count,
                TotalPrice = Convert.ToInt32(commodity.Price * model.Count),
                //单价
                Price = Convert.ToInt32(commodity.Price),
                RowStatus = 1,
                CreateDate = DateTime.Now,
                CreateUser = model.OpenId,
                UpdateDate = DateTime.Now,
                //利润
                Profit = Convert.ToInt32((commodity.Price - commodity.SalePrice) * model.Count)
            };
            var res = _db.OrderEntity.Add(order);
            _db.SaveChanges();
            return result;
        }

        public BaseResponse<OrderViewModel> GetOrderList(string openid)
        {
            var result = new BaseResponse<OrderViewModel>() { IsSuccess = true, Code = "10000", Message = "成功" };
            var sql = new StringBuilder();
            sql.AppendFormat(@"SELECT o.Id AS OrderId,c.Title,o.Price,o.[Count],o.CommodityId,o.TotalPrice,c.ImgUrl,o.CreateDate,o.OrderStatus FROM [Order] o
LEFT JOIN Commodity c ON o.CommodityId = c.Id
WHERE o.OpenId = '{0}' AND o.OrderStatus IN (1,2) AND o.RowStatus = 1", openid);
            var list = _db.OrderInfoModel.FromSql(sql.ToString()).ToList();
            if (list.Any())
            {
                result.Result = new OrderViewModel()
                {
                    StatusI_OrderList = new OrdersModel()
                    {
                        TotalPrice = 0,
                        OrderList = new List<OrderListModel>()
                    },
                    StatusII_OrderList = new OrdersModel()
                    {
                        TotalPrice = 0,
                        OrderList = new List<OrderListModel>()
                    }
                };
                result.Result.StatusI_OrderList.TotalPrice = list.Where(t => t.OrderStatus == 1).Sum(t => t.TotalPrice);
                result.Result.StatusII_OrderList.TotalPrice = list.Where(t => t.OrderStatus == 2).Sum(t => t.TotalPrice);
                list.ForEach(t =>
                {
                    if (t.OrderStatus == 1)
                    {
                        result.Result.StatusI_OrderList.OrderList.Add(new OrderListModel
                        {
                            OrderId = t.OrderId,
                            CommodityId = t.CommodityId,
                            CommodityTitle = t.Title,
                            CommodityPrice = t.Price.ToString(),
                            TotalPrice = t.TotalPrice.ToString(),
                            Count = t.Count.ToString(),
                            OrderDate = t.CreateDate.ToString("yyyy-MM-dd HH:MM:ss"),
                            Url = t.ImgUrl
                        });
                    }
                    else if (t.OrderStatus == 2)
                    {
                        result.Result.StatusII_OrderList.OrderList.Add(new OrderListModel
                        {
                            OrderId = t.OrderId,
                            CommodityId = t.CommodityId,
                            CommodityTitle = t.Title,
                            CommodityPrice = t.Price.ToString(),
                            TotalPrice = t.TotalPrice.ToString(),
                            Count = t.Count.ToString(),
                            OrderDate = t.CreateDate.ToString("yyyy-MM-dd HH:MM:ss"),
                            Url = t.ImgUrl
                        });
                    }

                });
            }
            return result;
        }
    }
}
