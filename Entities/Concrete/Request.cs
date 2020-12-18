using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Request:IEntity
    {
        public int Id { get; set; }
        public int RequestFrom { get; set; }
        public bool Accepted { get; set; }
        public int RequestTo { get; set; }

       // public ICollection<User> RequestFrom { get; set; } 
       // public ICollection<User> RequestTo { get; set; }
    }
}
