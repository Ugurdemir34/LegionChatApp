using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserFriendMessageListDto :IDto
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public string MessageContent { get; set; }
        public DateTime DeliveredDate{ get; set; }
    
    }
}
