using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sundown2._0.Data;
using Sundown2._0.Models;
using Sundown2._0.Services;
using System;
using System.Threading.Tasks;

namespace Sundown2._0.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;

        public UserController(
           IUserService userService,
           IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }
        
        
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm]UserDTO model)
        {
            var response = _userService.Create(model);

            return Ok(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAll();

            return Ok(response);
        }


        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(Guid id)
        {
            var response = _userService.GetById(id);

            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update([FromForm] UserDTO model, Guid id)
        {
            var response = _userService.Update(model, id);

            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var response = _userService.Delete(id);

            return Ok(response);
        }

        
    }
}
