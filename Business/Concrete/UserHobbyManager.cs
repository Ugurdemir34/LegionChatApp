using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserHobbyManager : IUserHobbyService
    {
        private IUserHobbyDal _userHobbyDal;
        public UserHobbyManager(IUserHobbyDal userHobbyDal)
        {
            _userHobbyDal = userHobbyDal;
        }
        public void AddUserHobby(List<UserHobby> userHobby)
        {
            _userHobbyDal.AddRange(userHobby);
        }
    }
}
