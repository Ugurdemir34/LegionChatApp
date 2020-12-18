using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebUIBlazor.Services.Abstract;

namespace WebUIBlazor.Services.Concrete
{
    public class UserService : IUserService
    {
        private HttpClient _httpClient;
     
        public UserService(HttpClient httpClient )
        {
            _httpClient = httpClient;
        }
        public Task<List<UserHobbyDto>> GetCommunity(int id)
        {
            return _httpClient.GetFromJsonAsync<List<UserHobbyDto>>("https://localhost:44399/api/community/getcommunity?id=" + id);
        }

        public Task Add(UserForRegisterDto registerModel)
        {
            return _httpClient.PostAsJsonAsync("https://localhost:44399/api/auth/register", registerModel);
        }

        public Task<UserForCommunityDetailDto> GetCommunityDetail(int curretnuserid,int id)
        {
            return _httpClient.GetFromJsonAsync<UserForCommunityDetailDto>("https://localhost:44399/api/community/getcommunitydetail?id=" + id+"&currentuserid="+curretnuserid);
        }

        public Task<UserFriendListDto> GetFriendList(int userid)
        {
            return _httpClient.GetFromJsonAsync<UserFriendListDto>("https://localhost:44399/api/community/getuserfriendlist?userid=" + userid );
        }
    }
}
