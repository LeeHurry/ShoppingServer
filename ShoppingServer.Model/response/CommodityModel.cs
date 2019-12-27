using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingServer.Model.response
{
    /// <summary>
    /// 
    /// </summary>
    public class CommodityModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 产品标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 产品价格
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public string SalePrice { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public string Stock { get; set; }
        /// <summary>
        /// 产品图片
        /// </summary>
        public string ImgUrl { get; set; }
        public string Describe { get; set; }
        public string Total { get; set; }
    }

    /// <summary>
    /// 瀑布流列表页
    /// </summary>
    public class MainCommodityResponse
    {
        /// <summary>
        /// 左侧
        /// </summary>
        public List<CommodityModel> LeftList { get; set; }
        /// <summary>
        /// 右侧
        /// </summary>
        public List<CommodityModel> RightList { get; set; }
    }


}
