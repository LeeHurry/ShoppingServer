using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingServer.Model.response
{
    public class OrderViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public OrdersModel StatusI_OrderList { get; set; }
        public OrdersModel StatusII_OrderList { get; set; }
    }

    public class OrdersModel
    {
        public int TotalPrice { get; set; }
        public List<OrderListModel> OrderList { get; set; }
    }

    public class OrderListModel
    {
        public long OrderId { get; set; }
        public long CommodityId { get; set; }
        public string CommodityTitle { get; set; }

        public string CommodityPrice { get; set; }

        public string TotalPrice { get; set; }

        public string OrderDate { get; set; }
        public string Count { get; set; }
        public string Url { get; set; }

    }
}
