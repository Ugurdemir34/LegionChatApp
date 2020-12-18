using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Country :IEntity
    {
        public int Id { get; set; }
        public string CodeTwoDigit { get; set; }
        public string CodeThreeDigit { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }
    }
}
