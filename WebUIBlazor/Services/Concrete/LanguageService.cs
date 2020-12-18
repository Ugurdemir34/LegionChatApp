using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebUIBlazor.Services.Abstract;

namespace WebUIBlazor.Services.Concrete
{
    public class LanguageService : ILanguageService
    {
        
        private HttpClient _httpClient;
        public LanguageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<List<Language>> GetLanguages()
        {
            return _httpClient.GetFromJsonAsync<List<Language>>("https://localhost:44399/api/language/getlanguages");
        }
    }
}
