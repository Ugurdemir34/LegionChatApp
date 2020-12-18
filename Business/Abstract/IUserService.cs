using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        //void Add(User user);
        User GetByMail(string email);
        IDataResult<List<UserHobbyDto>> GetCommunity(int id);
        User GetById(int id);
        void AddUser(User user);
        IDataResult<UserForCommunityDetailDto> GetDetailById(int currentuserid,int id);
        IDataResult<UserFriendListDto> GetUserFriendList(int userid);
       
    }
}
