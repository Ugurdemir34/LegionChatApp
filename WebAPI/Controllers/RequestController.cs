using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebAPI.DataProvider;
using WebAPI.Hubs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly BroadcastHub _hub;
        private readonly TimerManager _timer;
        private IRequestService _requestService;
        public RequestController(BroadcastHub hub, TimerManager timer, IRequestService requestService)
        {
            _hub = hub;
            _timer = timer;
            _requestService = requestService;
        }
        [HttpGet("getrequestcount")]
        public IActionResult GetRequestCount(int userid)
        {
            // _hub.SendRequestCount(userid,connectionId);
            var model = _requestService.GetRequestCount(userid);
            return Ok(model);
        }
        [HttpGet("getrequeststate")]
        public IActionResult GetRequestState(int userid, int anotherpersonid)
        {
            var model = _requestService.GetRequestState(userid, anotherpersonid);
            return Ok(model);
        }
        [HttpPost("addrequest")]
        public IActionResult AddRequest(Request request)
        {
            _requestService.Add(request);
            return Ok();
        }
        [HttpPost("updaterequest")]
        public IActionResult Update(RequestUpdateDto requestUpdateDto)
        {
         
            var request = _requestService.Get(requestUpdateDto.Id);
            if (request == null)
            {
                return NotFound();
            }
            request.Accepted = requestUpdateDto.Accepted;
            _requestService.Update(request);
            return Ok();
        }
        [HttpGet("requestfriendlist")]
        public IActionResult FriendList(int userid)
        {

            var request = _requestService.GetRequestFriendList(userid);
            if (request == null)
                return BadRequest();
           
            return Ok(request);
        }

    }
}
