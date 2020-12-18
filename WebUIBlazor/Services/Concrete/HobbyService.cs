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
    public class HobbyService : IHobbyService
    {
        private HttpClient _httpClient;
        public HobbyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CallHobbyEndPoint()
        {
            try
            {
                var result = await _httpClient.GetAsync("broadcast");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }
        public Task<List<Hobby>> GetHobbies()
        {
            return _httpClient.GetFromJsonAsync<List<Hobby>>("https://localhost:44399/api/hobby/gethobbies");
        }
    }
}
