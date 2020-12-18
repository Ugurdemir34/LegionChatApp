using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserLanguageManager : IUserLanguageService
    {
        private IUserLanguageDal _userLanguageDal;
        public UserLanguageManager(IUserLanguageDal userLanguageDal)
        {
            _userLanguageDal = userLanguageDal;
        }
        public void AddUserLanguage(List<UserLanguage> userLanguage)
        {
            _userLanguageDal.AddRange(userLanguage);
        }
    }
}
