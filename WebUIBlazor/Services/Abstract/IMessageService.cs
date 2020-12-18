using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIBlazor.Services.Abstract
{
    public interface IMessageService
    {
        Task<List<UserFriendMessageListDto>> GetFriendMessageList(int userid,int friendid);
        Task AddMessage(LastMessageDto newMessage);
        Task DeleteMessage();
    }
}
