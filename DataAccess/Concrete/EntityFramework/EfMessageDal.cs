using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, LegionContext>, IMessageDal
    {
        public List<UserFriendMessageListDto> GetConversation(int userid, int friendid)
        {
            using (var _context = new LegionContext())
            {
                var result = new List<UserFriendMessageListDto>();
                //if (_context.Messages.Contains(new Message() { MessageFrom= userid,MessageTo=friendid}))
                //{
                //    result = _context.Messages.Where(i => i.MessageFrom == userid && i.MessageTo == friendid)
                //                              .Select(i => new UserFriendMessageListDto() 
                //                              {
                //                                  DeliveredTime = i.DeliveredTime,
                //                                  FriendId = friendid,
                //                                  UserId = userid,
                //                                  MessageContent = i.MessageContent
                //                              }).ToList();
                //}
               // if (_context.Messages.Contains(new Message() { MessageFrom = friendid, MessageTo = friendid }))
               // {
                    result = _context.Messages.Where(i => i.MessageFrom == userid && i.MessageTo == friendid || i.MessageFrom==friendid && i.MessageTo == userid)
                                              .Select(i => new UserFriendMessageListDto()
                                              {
                                                  DeliveredDate = i.DeliveredDate,
                                                  FriendId = i.MessageTo,
                                                  UserId = i.MessageFrom,
                                                  MessageContent = i.MessageContent
                                              }).ToList();
               // }
                return result;
            }
        }
    }
}
