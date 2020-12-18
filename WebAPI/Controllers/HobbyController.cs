using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebAPI.DataProvider;
using WebAPI.Hubs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private IHobbyService _hobbyService;
        private readonly IHubContext<BroadcastHub> _hub;
        private readonly TimerManager _timer;
        public HobbyController(IHobbyService hobbyService, IHubContext<BroadcastHub> hub, TimerManager timer)
        {
            _hobbyService = hobbyService;
            _hub = hub;
            _timer = timer;
        }
        [HttpGet("gethobbies")]
        public IActionResult GetHobbies()
        {

            var model = _hobbyService.GetList().Data;
            return Ok(model);
        }
    }
}