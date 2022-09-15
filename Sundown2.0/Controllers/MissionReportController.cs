using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sundown2._0.Data;
using Sundown2._0.Models;
using Sundown2._0.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Controllers
{
    




    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MissionReportController : ControllerBase
    {
        private readonly IMissionReportService _missionReportService;

        public MissionReportController(IMissionReportService missionReportService)
        {
            _missionReportService = missionReportService;
        }

        
        [AllowAnonymous]
        [HttpPost("uploadreport")]
        public IActionResult CreateMissionReport(MissionReportRequestModel model)
        {
            

            var response = _missionReportService.CreateMissionReport(model);

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
