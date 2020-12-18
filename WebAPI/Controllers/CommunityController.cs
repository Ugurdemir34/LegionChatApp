using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private IUserService _userService;
        public CommunityController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpGet("getcommunity")]
        public IActionResult GetCommunity(int id)
        {
            var result = _userService.GetCommunity(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getcommunitydetail")]
        public IActionResult GetCommunityDetail(int currentuserid,int id)
        {
            var result = _userService.GetDetailById(currentuserid,id);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getuserfriendlist")]
        public IActionResult GetFriendList(int userid)
        {
            var result = _userService.GetUserFriendList(userid);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
            
        }
    }
}