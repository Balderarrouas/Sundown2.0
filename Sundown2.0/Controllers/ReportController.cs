using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sundown2._0.Models;
using Sundown2._0.Services;
using System.Linq;
using System.Security.Claims;

namespace Sundown2._0.Controllers
{





    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMissionReportService _missionReportService;

        public ReportController(IMissionReportService missionReportService)
        {
            _missionReportService = missionReportService;
        }

        

       
       
        
        [HttpPost("create")]
        public IActionResult Create(MissionReportRequestModel model)
        {
            var x = HttpContext;
            var jwt = x.Request.Headers["Authorization"];
            var userIdString = x.User?.Claims.First(x => x.Type == ClaimTypes.UserData).Value;
            var userId = int.Parse(userIdString);
            
            var response = _missionReportService.Create(model, userId);

            return Ok(response);
        }










        [AllowAnonymous]
        [HttpPost("uploadimage")]
        public IActionResult UploadMissionImage([FromForm] MissionImageRequestModel model)
        {

            _missionReportService.UploadMissionImage(model);
            return Ok();
        }


    }
}
