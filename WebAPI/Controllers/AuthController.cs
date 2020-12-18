using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;
        private IUserLanguageService _userLanguageService;
        private IUserHobbyService _userHobbyService;
        public AuthController(IAuthService authService, IUserService userService,IUserLanguageService userLanguageService, IUserHobbyService userHobbyService)
        {
            _authService = authService;
            _userLanguageService = userLanguageService;
            _userService = userService;
            _userHobbyService = userHobbyService;
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if(!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if(result.Success)
            {
               
                return Ok(result.Data);
            }
            
            return BadRequest(result.Message);
        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if(!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            byte[] passwordHash, passwordSalt;        
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                About = userForRegisterDto.About,
                Birthday = userForRegisterDto.Birthday,
                City = userForRegisterDto.City,
                Country = userForRegisterDto.Country,
                Email = userForRegisterDto.Email,
                LastName = userForRegisterDto.LastName,
                Name = userForRegisterDto.FirstName,
                NativeLanguage = userForRegisterDto.NativeLanguage,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Photo = userForRegisterDto.Photo,
               // ProfileCreatedDate = userForRegisterDto.ProfileCreatedDate,
                Sex = userForRegisterDto.Sex,
                UserName = userForRegisterDto.UserName
            };
            var registerResult = _authService.Register(user,userForRegisterDto.Password);
          
            List<UserLanguage> userLanguage = new List<UserLanguage>();
            List<UserHobby> userHobby = new List<UserHobby>();
            for (int i = 0; i < userForRegisterDto.Languages.Count; i++)
            {
                userLanguage.Add(new UserLanguage
                {
                    User = registerResult.Data,
                    Language = new Language
                    {
                        Id = userForRegisterDto.Languages[i].Id
                    }
                });
            }
            for (int i = 0; i < userForRegisterDto.Hobbies.Count; i++)
            {
                userHobby.Add(new UserHobby
                {
                    User = registerResult.Data,
                    Hobby = new Hobby
                    {
                        Id = userForRegisterDto.Hobbies[i].Id
                    }
                });
            }
            _userLanguageService.AddUserLanguage(userLanguage);
            _userHobbyService.AddUserHobby(userHobby);
            var result = _authService.CreateAccessToken(user);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}