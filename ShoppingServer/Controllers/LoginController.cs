using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingServer.Model.response;

namespace ShoppingServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public string GetOpenId(string code)
        {
            var url = $"https://api.weixin.qq.com/sns/jscode2session?appid=wx997e41bafb66b173&secret=44b3f33f9b776aa540f00444aa9c9e5c&js_code=" + code + "&grant_type=authorization_code";
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
            };
            var res = httpClient.SendAsync(request);
            res.Wait();
            var resp = res.Result;
            Task<string> temp = resp.Content.ReadAsStringAsync();
            temp.Wait();
            return JsonConvert.DeserializeObject<WechatOpenIdModel>(temp.Result).openid;
        }
    }
}