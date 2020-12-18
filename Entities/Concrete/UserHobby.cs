using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserHobby:IEntity
    {
      
        public int UserId { get; set; }
        public int HobbyId { get; set; }
        public virtual User User { get; set; }
        public virtual Hobby Hobby { get; set; }
    }
}
