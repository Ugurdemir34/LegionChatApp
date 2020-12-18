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
using WebAPI.Hubs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageService _messageService;
        private readonly IHubContext<BroadcastHub> _hub;
        public MessageController(IMessageService messageService, IHubContext<BroadcastHub> hub)
        {
            _messageService = messageService;
            _hub = hub;

        }
        [HttpGet("getmessages")]
        public IActionResult GetMessages(int userid, int friendid)
        {
            var result = _messageService.GetList(userid, friendid);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("addmessage")]
        public IActionResult AddMessage(LastMessageDto newMessage)
        {
            if(ModelState.IsValid)
            {
                newMessage.DeliveredDate = DateTime.Now;
                var message = new Message
                {
                    DeliveredDate = newMessage.DeliveredDate,
                    MessageContent = newMessage.MessageContent,
                    MessageFrom = newMessage.MessageFrom,
                    MessageTo = newMessage.MessageTo
                };
                _messageService.Add(message);
               
              //  _hub.Clients.Client(newMessage.connectionId).SendAsync("messagetransfer", newMessage);
                return Ok();
            }          
            return BadRequest();
        }
    }
}
