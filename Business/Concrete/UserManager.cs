using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
      /*  public void Add(User user)
        {
            _userDal.Add(user);
        }*/

        public void AddUser(User user)
        {
             _userDal.Add(user);        
        }

        public User GetById(int id)
        {
            return _userDal.Get(i => i.Id == id);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(i => i.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<List<UserHobbyDto>> GetCommunity(int id)
        {
            return new SuccessDataResult<List<UserHobbyDto>>(_userDal.GetCommunity(id));
        }

        public IDataResult<UserForCommunityDetailDto> GetDetailById(int currentuserid,int id)
        {
            return new SuccessDataResult<UserForCommunityDetailDto>(_userDal.GetDetailById(currentuserid,id));
        }

        public IDataResult<UserFriendListDto> GetUserFriendList(int userid)
        {
            return new SuccessDataResult<UserFriendListDto>(_userDal.GetFriendList(userid));
        }
    }
}
