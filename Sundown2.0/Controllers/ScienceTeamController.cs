using Microsoft.AspNetCore.Mvc;
using Sundown2._0.Services;
using System;

namespace Sundown2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScienceTeamController : ControllerBase
    {

        private readonly IMissionReportService _missionReportService;
        private readonly IMissionImageService _missionImageService;

        public ScienceTeamController(IMissionReportService missionReportService, IMissionImageService missionImageService)
        {
            _missionReportService = missionReportService;
            _missionImageService = missionImageService;
        }



        [HttpGet("getAllReports")]
        public IActionResult GetAllReports()
        {
            var response = _missionReportService.GetAll();

            return Ok(response);
        }

        
        [HttpGet("getReportById/{id}")]
        public IActionResult GetReportById(Guid id)
        {
            var response = _missionReportService.GetById(id);

            return Ok(response);
        }


        [HttpGet("getAllImages")]
        public IActionResult GetAllImages()
        {
            var response = _missionImageService.GetAll();

            return Ok(response);
        }


        [HttpGet("getImageById/{id}")]
        public IActionResult GetImageById(Guid id)
        {
            var response = _missionImageService.GetById(id);

            return Ok(response);
        }
    }
}
