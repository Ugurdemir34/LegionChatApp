using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIBlazor.Dtos
{
    public class NotificationDto
    {
        public int UserId { get; set; }
        public string MessageContent { get; set; }
        public int FriendId { get; set; }
    }
}
