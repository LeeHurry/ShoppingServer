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
        public dynamic GetCommodityList()
        {
            var result = new List<CommodityModel>();
            result = new MainBll(_db).GetCommodityList();
            return result;
        }
        [HttpPost]
        public BaseResponse AddCommondity(CommodityModel model)
        {
            var result = new BaseResponse();
            result = new MainBll(_db).AddCommondity(model);
            return result;
        }
        
        
    }
}