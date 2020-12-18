using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RequestFriendListDto:IDto
    {
        public int UserId { get; set; }
        public List<User> Friends { get; set; } = new List<User>();
        public List<string> LastMessages { get; set; } =new List<string>();
        public virtual User User { get; set; }

    }
}
