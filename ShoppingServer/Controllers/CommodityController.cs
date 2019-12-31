using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingServer.Bll;
using ShoppingServer.Model;
using ShoppingServer.Model.response;

namespace ShoppingServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommodityController : ControllerBase
    {
        DataContext _db;
        public CommodityController(DataContext dbContext)
        {
            _db = dbContext;
        }
        /// <summary>
        /// 获取产品编辑列表
        /// </summary>
        /// <returns></returns>
        //public List<CommodityModel> GetCommondityList()
        //{

        //}
        public CommodityModel GetCommodityDetail(long id)
        {
            return new CommodityBll(_db).GetCommodity(id);
        }


    }
}