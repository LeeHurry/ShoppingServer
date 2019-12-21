using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingServer.Model.tableModel
{
    /// <summary>
    /// 产品信息
    /// </summary>
    [Table("Commodity")]
    public class CommodityEntity
    {
        public CommodityEntity()
        {
            RowStatus = 1;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 产品标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 结算价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 库存总量
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 已售数量
        /// </summary>
        public int Sale { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 行状态
        /// </summary>
        public int RowStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
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
