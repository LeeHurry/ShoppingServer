using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingServer.Model.tableModel
{
    [Table("UserInfo")]
    public class UserInfoEntity
    {
        [Key]
        public string OpenId { get; set; }

        public string NickName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
