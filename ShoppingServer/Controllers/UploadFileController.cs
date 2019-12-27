using System;
using System.Web;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace ShoppingServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        [HttpPost]
        public async System.Threading.Tasks.Task<string> SavePicByUrlAsync(IList<IFormFile> files)
        {
            var file = Request.Form.Files;
            var name = "./Image/" + Guid.NewGuid() + ".jpg";
            foreach (var item in file)
            {
                var bytes = new byte[item.Length];
                await item.OpenReadStream().ReadAsync(bytes);
                var stream = new MemoryStream(bytes);
                Image img = Image.FromStream(stream);
                try
                {
                    img.Save(name.ToString(), ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {

                }

            }
            return name;
        }
    }
}