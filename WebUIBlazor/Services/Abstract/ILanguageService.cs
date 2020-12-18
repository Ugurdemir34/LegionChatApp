using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIBlazor.Services.Abstract
{
    public  interface ILanguageService
    {
        Task<List<Language>> GetLanguages();
    }
}
