using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);//JOIN OPERASYONU
        List<UserHobbyDto> GetCommunity(int id);
        // User AddUser(User registerDto);
        UserForCommunityDetailDto GetDetailById(int currentuserid,int id);
        UserFriendListDto GetFriendList(int userid);
    }
}
