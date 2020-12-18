using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRequestDal :IEntityRepository<Request>
    {
        int GetRequestCount(int userid);
        RequestStateDto GetRequestState(int userid, int anotherpersonid);
        RequestFriendListDto GetFriendList(int userid);

    }
}
