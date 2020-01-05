using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingServer.Model.tableModel
{
    /// <summary>
    /// 数据库订单实体
    /// </summary>
    [Table("Order")]
    public class OrderEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 订单状态，0取消，1待收货，2已收货
        /// </summary>
        public int OrderStatus { get; set; }
        /// <summary>
        /// 微信OPENID
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long CommodityId { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 订单总价
        /// </summary>
        public int TotalPrice { get; set; }
        /// <summary>
        /// 产品单价
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public int Profit { get; set; }
        /// <summary>
        /// 行状态
        /// </summary>
        public int RowStatus { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateUser { get; set; }
    }
}
