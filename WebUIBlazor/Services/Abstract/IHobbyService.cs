using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIBlazor.Services.Abstract
{
    public interface IHobbyService
    {
        Task<List<Hobby>> GetHobbies();
        Task CallHobbyEndPoint();
    }
}
