using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIBlazor.Models
{
    public class TokenModel
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
 
        
    }
}
