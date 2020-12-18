using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        [HttpGet("getlanguages")]
        public IActionResult GetLanguages()
        {
            var model = _languageService.GetLanguages();
            if(model.Success)
            {
                return Ok(model.Data);
            }
            return BadRequest(model.Message);
           
        }
    }
}