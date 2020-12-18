using Entities.Concrete;
using Entities.Dtos;
using Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIBlazor.Services.Abstract
{
    public interface IRequestService
    {
        Task<int> GetRequestCount(int userid);
        Task<RequestStateDto> GetRequestState(int userid,int anotherpersoneid);
        Task CallRequestEndPoint();
        Task Add(Request request);
        Task Update(RequestUpdateDto request);
        Task<RequestFriendListDto> GetFriendList(int userid);
    }
}
