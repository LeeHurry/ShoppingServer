using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingServer.Model.customModel
{
    public class OrderInfoModel
    {
        [Key]
        public long OrderId { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public long CommodityId { get; set; }

        public int TotalPrice { get; set; }

        public string ImgUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public int OrderStatus { get; set; }    

    }
}
