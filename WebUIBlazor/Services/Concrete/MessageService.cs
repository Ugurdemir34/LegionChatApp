using Entities.Concrete;
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
    public class MessageService : IMessageService
    {

        private HttpClient _httpClient;
        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task AddMessage(LastMessageDto newMessage)
        {
            return _httpClient.PostAsJsonAsync("https://localhost:44399/api/message/addmessage", newMessage);
        }

        public Task DeleteMessage()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserFriendMessageListDto>> GetFriendMessageList(int userid, int friendid)
        {
            return _httpClient.GetFromJsonAsync<List<UserFriendMessageListDto>>("https://localhost:44399/api/message/getmessages?userid="+userid+"&friendid="+friendid);
        }
    }
}
