using Entities.Concrete;
using Entities.Dtos;
using Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebUIBlazor.Services.Abstract;

namespace WebUIBlazor.Services.Concrete
{
    public class RequestService : IRequestService
    {
        private HttpClient _httpClient;
        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Add(Request request)
        {
            return _httpClient.PostAsJsonAsync("https://localhost:44399/api/request/addrequest", request);
        }

        public async Task CallRequestEndPoint()
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

        public Task<RequestFriendListDto> GetFriendList(int userid)
        {
            return _httpClient.GetFromJsonAsync<RequestFriendListDto>("https://localhost:44399/api/request/requestfriendlist?userid=" + userid);
        }

        public Task<int> GetRequestCount(int userid)
        {
            return _httpClient.GetFromJsonAsync<int>("https://localhost:44399/api/request/getrequestcount?userid=" + userid);
        }

        public Task<RequestStateDto> GetRequestState(int userid, int anotherpersoneid)
        {
            return _httpClient.GetFromJsonAsync<RequestStateDto>("https://localhost:44399/api/request/getrequeststate?userid=" + userid+"&anotherpersonid="+anotherpersoneid);
        }

        public Task Update(RequestUpdateDto request)
        {
            return _httpClient.PostAsJsonAsync("https://localhost:44399/api/request/updaterequest", request);
        }
    }
}
