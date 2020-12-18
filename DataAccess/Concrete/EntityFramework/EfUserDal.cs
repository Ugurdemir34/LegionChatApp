using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using DataAccess.Utilities.Security.Hashing;
using System;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, LegionContext>, IUserDal
    {
        //public UserForRegisterDto AddUser(UserForRegisterDto userForRegisterDto)
        //{
        //    using (var context = new LegionContext())
        //    {
        //        byte[] passwordHash, passwordSalt;
        //        List<UserLanguage> userLanguages = new List<UserLanguage>();

        //        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
        //        var user = new User
        //        {
        //            Email = userForRegisterDto.Email,
        //            Name = userForRegisterDto.FirstName,
        //            LastName = userForRegisterDto.LastName,
        //            PasswordHash = passwordHash,//out olduğu için passwordHash dolduruldu
        //            PasswordSalt = passwordSalt,
        //            About = userForRegisterDto.About,
        //            Birthday = userForRegisterDto.Birthday,
        //            NativeLanguage = userForRegisterDto.NativeLanguage,
        //            PhoneNumber = userForRegisterDto.PhoneNumber,
        //            Photo = userForRegisterDto.Photo,
        //            UserName = userForRegisterDto.UserName,
        //            ProfileCreatedDate = DateTime.Now,
        //            City = userForRegisterDto.City,
        //            Country = userForRegisterDto.Country,
        //            Sex = userForRegisterDto.Sex
        //        };                           
        //        context.Users.Add(user);                          
        //        context.SaveChanges();
        //        return userForRegisterDto;

        //    }
        //}
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new LegionContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
        public List<UserHobbyDto> GetCommunity(int id)
        {
            using (var context = new LegionContext())
            {
                var model = from user in context.Users
                            where user.Id != id
                            select new UserHobbyDto
                            {
                                Id = user.Id,
                                Name = user.Name,
                                About = user.About,
                                Birthday = user.Birthday,
                                City = user.City,
                                Country = user.Country,
                                Email = user.Email,
                                LastName = user.LastName,
                                NativeLanguage = user.NativeLanguage,
                                PhoneNumber = user.PhoneNumber,
                                Photo = user.Photo,
                                //ProfileCreatedDate = user.ProfileCreatedDate,
                                Sex = user.Sex,
                                UserName = user.UserName,
                                Hobbies = (from userhobby in context.UserHobbies
                                           join hobby in context.Hobbies on userhobby.HobbyId equals hobby.Id
                                           where userhobby.UserId == user.Id
                                           select new Hobby
                                           {
                                               Id = hobby.Id,
                                               Name = hobby.Name
                                           }).ToList(),
                                Languages = (from userlanguage in context.UserLanguages
                                             join language in context.Languages on userlanguage.LanguageId equals language.Id
                                             where userlanguage.UserId == user.Id
                                             select new Language
                                             {
                                                 Id = language.Id,
                                                 LanguageName = language.LanguageName,
                                                 CountryCode = language.CountryCode
                                             }).ToList(),
                                isFriend = context.Friends.Where(i => i.UserId == id).Any(a => a.UserFriendId == user.Id)
                            };
                return model.ToList();
            }
        }

        public UserForCommunityDetailDto GetDetailById(int currentuserid, int id)
        {
            using (var context = new LegionContext())
            {
                var result = from user in context.Users
                             where user.Id == id
                             select new UserForCommunityDetailDto
                             {
                                 About = user.About,
                                 Birthday = user.Birthday,
                                 City = user.City,
                                 Country = user.Country,
                                 LastName = user.LastName,
                                 Name = user.Name,
                                 Photo = user.Photo,
                                 NativeLanguage = user.NativeLanguage,
                                 ProfileCreatedDate = user.ProfileCreatedDate,
                                 Sex = user.Sex,
                                 UserName = user.UserName,
                                 Friendship = (context.Friends.Where(i => i.UserId == currentuserid && i.UserFriendId == id).Any()),
                                 Hobbies = (from hobby in context.Hobbies join userhobby in context.UserHobbies on hobby.Id equals userhobby.HobbyId where userhobby.UserId == id select hobby).ToList(),
                                 Languages = (from language in context.Languages join userlanguage in context.UserLanguages on language.Id equals userlanguage.LanguageId where userlanguage.UserId == id select language).ToList(),

                             };
                return result.FirstOrDefault();
            }
        }

        public UserFriendListDto GetFriendList(int userid)
        {
            using (var context = new LegionContext())
            {
                //var model = new UserFriendListDto();

                //var user = from user in context.Users
                //             join req in context.Requests on user.Id equals req.RequestFrom
                //             where user.Id == userid && req.Accepted == true
                //             select new User
                //             {
                //                 UserId = user.Id,
                //                 User = new User { Name = user.Name,LastName = user.LastName},
                //                 Friends = (from u in context.Users where u.Id == req.RequestTo select new User { Name =u.Name,LastName=u.LastName}).ToList(),
                //             }.User;
                //model.User = user.FirstOrDefault();
                //for (int i = 0; i < ; i++)
                //{

                //}
                //return result.FirstOrDefault();
                var model = new UserFriendListDto();
                var res1 = from user in context.Users
                           join req in context.Requests on user.Id equals req.RequestFrom
                           where user.Id == userid && req.Accepted == true
                           select req;
                
                for (int i = 0; i < res1.ToList().Count; i++)
                {
                    model.Friends.Add(context.Users.Where(a => a.Id == res1.ToList()[i].RequestTo).FirstOrDefault());
                }
                var res2 = from user in context.Users
                             join req in context.Requests on user.Id equals req.RequestFrom
                             where user.Id == userid && req.Accepted == true
                             select user;
                model.User = res2.FirstOrDefault();
                return model;
            }
        }
    }
}
