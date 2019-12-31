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
    public class MainController : ControllerBase
    {
        DataContext _db;
        public MainController(DataContext dbContext)
        {
            _db = dbContext;
        }
        public List<CommodityModel> GetCommodityList()
        {
            var result = new List<CommodityModel>();
            result = new MainBll(_db).GetCommodityList();
            return result;
        }
        [HttpPost]
        public BaseResponse AddCommodity(CommodityModel model)
        {
            var result = new BaseResponse();
            result = new MainBll(_db).AddCommondity(model);
            return result;
        }
        /// <summary>
        /// 获取左右瀑布流的列表
        /// </summary>
        /// <returns></returns>
        public MainCommodityResponse GetMainCommodityList()
        {
            var res = new MainCommodityResponse() { LeftList = new List<CommodityModel>(), RightList = new List<CommodityModel>() };
            var list = new MainBll(_db).GetCommodityList();
            if (list.Any())
            {
                var index = 1;
                list.ForEach(t =>
                {
                    if (index == 1)
                    {
                        res.LeftList.Add(t);
                        index = 0;
                    }
                    else
                    {
                        res.RightList.Add(t);
                        index = 1;
                    }
                });
            }

            return res;
        }

    }
}