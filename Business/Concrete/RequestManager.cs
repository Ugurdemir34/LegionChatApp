using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RequestManager : IRequestService
    {
        private IRequestDal _requestDal;
        public RequestManager(IRequestDal requestDal)
        {
            _requestDal = requestDal;
        }

        public void Add(Request request)
        {
            _requestDal.Add(request);
        }

        public Request Get(int id)
        {
           return _requestDal.Get(i => i.Id == id);
        }

        public int GetRequestCount(int userid)
        {
            return _requestDal.GetRequestCount(userid);
        }

        public RequestFriendListDto GetRequestFriendList(int userid)
        {
            return _requestDal.GetFriendList(userid);
        }

        public RequestStateDto GetRequestState(int userid, int anotherpersoneid)
        {
            return _requestDal.GetRequestState(userid, anotherpersoneid);
        }

        public void Update(Request request)
        {
            _requestDal.Update(request);
        }
    }
}
