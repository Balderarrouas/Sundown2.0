using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sundown2._0.Data;
using Sundown2._0.Models;
using Sundown2._0.Services;


namespace Sundown2._0.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AstronautController(
           IUserService userService,
           IMapper mapper,
           IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        

        


        //[AllowAnonymous]
        //[HttpPost("register")]
        //public IActionResult Register(RegisterRequest model)
        //{
        //    _userService.Register(model);
        //    return Ok(new { message = "Registration successful" });
        //}
    }
}
