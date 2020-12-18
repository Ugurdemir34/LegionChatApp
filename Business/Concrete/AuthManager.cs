using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Utilities.Security.Hashing;
using DataAccess.Utilities.Security.Jwt;
using Entities.Dtos;
using System;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }           
          
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }
        public IDataResult<User> Register(User model,string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                About = model.About,
                Birthday = model.Birthday,
                City = model.City,
                Country = model.Country,
                Email = model.Email,
                LastName = model.LastName,
                Name = model.Name,
                NativeLanguage = model.NativeLanguage,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PhoneNumber = model.PhoneNumber,
                Photo = model.Photo,
               // ProfileCreatedDate = model.ProfileCreatedDate,
                Sex = model.Sex,
                UserName = model.UserName
            };
            _userService.AddUser(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
                                 
        }
        public IDataResult<User> UserExists(string email)
        {
            var model = _userService.GetByMail(email);
            if (model!= null)
            {
                return new ErrorDataResult<User>(model, Messages.UserAlreadyExists);
            }
            return new SuccessDataResult<User>(model, Messages.UserFound);
        }
    }
}
