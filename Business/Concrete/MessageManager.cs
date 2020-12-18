using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult(Messages.MessageAdded);
        }       
        public List<UserFriendMessageListDto> GetList(int userid, int friendid)
        {
             return _messageDal.GetConversation(userid, friendid);
        }
    }
}
