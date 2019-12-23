using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingServer.Model.response
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Code = "10000";
            IsSuccess = true;
            Message = "成功！";
        }
        /// <summary>
        /// 状态位：10000成功
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
    }
}
