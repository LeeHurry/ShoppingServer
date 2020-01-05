using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingServer.Model.queryModel
{
    public class OrderQueryModel
    {
        public int OrderId { get; set; }

        public int CommodityId { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public int TotalPrice { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
