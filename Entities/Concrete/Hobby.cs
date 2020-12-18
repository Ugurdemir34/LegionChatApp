using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Hobby:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
    }
}
