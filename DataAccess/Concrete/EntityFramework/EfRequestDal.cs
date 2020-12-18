using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRequestDal : EfEntityRepositoryBase<Request, LegionContext>, IRequestDal
    {
        public RequestFriendListDto GetFriendList(int userid)
        {
            using (var context = new LegionContext())
            {
                //var friends = from request in context.Requests
                //              where request.RequestFrom == userid || request.RequestTo == userid
                //              join user in context.Users on request.RequestFrom
                //              select new RequestFriendListDto
                //              {
                //                  UserId = userid,
                //                  User = 
                //              }
                var model = new RequestFriendListDto();
                model.UserId = userid;
                if(context.Requests.Where(i=>i.RequestFrom == userid).Count()>0)
                {
                    model.User = (from user in context.Users where user.Id == userid select user).FirstOrDefault();
                    model.Friends = (from req in context.Requests where req.RequestFrom == userid join us in context.Users on req.RequestTo equals us.Id select us).ToList();
                   
                }
                if (context.Requests.Where(i => i.RequestTo == userid).Count() > 0)
                {
                    model.User = (from user in context.Users where user.Id == userid select user).FirstOrDefault();
                    model.Friends = (from req in context.Requests where req.RequestTo == userid join us in context.Users on req.RequestFrom equals us.Id select us).ToList();
                  
                }
                
                foreach (var friend in model.Friends)
                {
                    var value = context.Messages.OrderByDescending(i => i.DeliveredDate)?.Where(i => (i.MessageFrom == userid & i.MessageTo == friend.Id) || (i.MessageTo == userid & i.MessageFrom == friend.Id))?.FirstOrDefault()?.MessageContent;
                   
                    model.LastMessages.Add(value is null ? "":value);
                }
                return model;



            }
        }

        public int GetRequestCount(int userid)
        {
            using (var context = new LegionContext())
            {
                var result = context.Requests.Where(i => i.RequestTo == userid && i.Accepted == false).Count();
                return result;                    
            }
        }
        public RequestStateDto GetRequestState(int userid, int anotherpersonid)
        {
            using (var context = new LegionContext())
            {
                var result = new RequestStateDto();
                var condition1 = context.Requests.Where(i => i.RequestFrom == userid && i.RequestTo == anotherpersonid && i.Accepted == false);
                var condition2 = context.Requests.Where(i => i.RequestFrom == anotherpersonid && i.RequestTo == userid && i.Accepted == false);
                var condition3 = context.Requests.Where(i => i.RequestFrom == anotherpersonid && i.RequestTo == userid && i.Accepted == false);
                var condition4 = context.Requests.Where(i => i.RequestFrom == userid && i.RequestTo == anotherpersonid && i.Accepted == true);
                var condition5 = context.Requests.Where(i => i.RequestFrom == anotherpersonid && i.RequestTo == userid && i.Accepted == true);
                if (condition1.Any())
                {
                    result.Request = condition1.FirstOrDefault();
                    result.RequestStates = RequestStates.UserSent;
                }
                else if(condition2.Any())
                {
                    result.Request = condition2.FirstOrDefault();
                    result.RequestStates = RequestStates.PersonSent;
                }
                else if(condition4.Any() || condition5.Any())
                {
                    result.Request = condition4.FirstOrDefault();
                    result.RequestStates = RequestStates.AlreadyFriend;
                }
                else
                {
                    result.Request = null;
                    result.RequestStates = RequestStates.None;
                }
                return result;
            }
        }
    }
}
