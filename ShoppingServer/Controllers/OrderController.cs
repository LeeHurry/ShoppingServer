using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingServer.Bll;
using ShoppingServer.Model;
using ShoppingServer.Model.request;
using ShoppingServer.Model.response;

namespace ShoppingServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        DataContext _db;
        public OrderController(DataContext dbContext)
        {
            _db = dbContext;
        }
        [HttpPost]
        public BaseResponse CreateOrder(OrderModel model)
        {
            var result = new BaseResponse();
            result = new OrderBll(_db).CreateOrder(model);
            return result;
        }
        [HttpGet]
        public BaseResponse<OrderViewModel> GetOrderList(string openid)
        {
            var res = new BaseResponse<OrderViewModel>();
            res = new OrderBll(_db).GetOrderList(openid);
            return res;
        }
    }
}