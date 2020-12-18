using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserFriendListDto : IDto
    {
        public int UserId { get; set; }
        public List<User> Friends { get; set; } = new List<User>();

        public virtual User User { get; set; }
    }
}
