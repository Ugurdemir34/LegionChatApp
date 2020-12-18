using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserForCommunityDto
    {
        public IList<User> OtherUsers { get; set; }
    }
}
