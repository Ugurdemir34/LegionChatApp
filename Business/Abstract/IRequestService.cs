using Entities.Concrete;
using Entities.Dtos;
using Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    
    public interface IRequestService
    {
        int GetRequestCount(int userid);
        void Add(Request request);
        RequestStateDto GetRequestState(int userid, int anotherpersoneid);
        Request Get(int id);
        void Update(Request request);
        RequestFriendListDto GetRequestFriendList(int userid);
        
    }
}
