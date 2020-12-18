using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUIBlazor.Services.Abstract
{
    public interface IUserService
    {
        Task<List<UserHobbyDto>> GetCommunity(int id);
        Task Add(UserForRegisterDto registerModel);
        Task<UserForCommunityDetailDto> GetCommunityDetail(int currentuserid,int id);
        Task<UserFriendListDto> GetFriendList(int userid);
       
    }
}
