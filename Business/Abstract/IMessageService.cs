using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMessageService
    {
       IResult Add(Message message);
       List<UserFriendMessageListDto> GetList(int userid, int friendid);
    }
}
