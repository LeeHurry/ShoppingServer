using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingServer.Model.request
{
    /// <summary>
    /// 请求创建订单实体
    /// </summary>
    public class OrderModel
    {
        public string OpenId { get; set; }
        public string CommodityId { get; set; }
        public int Count { get; set; }
        public string NickName { get; set; }
    }
}
