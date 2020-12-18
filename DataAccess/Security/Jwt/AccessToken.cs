using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }    //Token geçerlilik süresi
    }
}
