using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sundown2._0.Models;
using Sundown2._0.Services;
using System;
using System.Linq;
using System.Security.Claims;
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


        
        [HttpPost("create")]
        public IActionResult Create(MissionReportDTO model)
        {
            var httpContext = HttpContext;
            
            var response = _missionReportService.Create(model, httpContext);

            return Ok(response);
        }

        
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _missionReportService.GetAll();

            return Ok(response);
        }

        
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(Guid id)
        {
            var response = _missionReportService.GetById(id);

            return Ok(response);
        }


        [HttpPut("update/{id}")]
        public IActionResult Update(MissionReportDTO model, Guid id)
        {          

            var response = _missionReportService.Update(model, id);

            return Ok(response);
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var response =  _missionReportService.Delete(id);

            return Ok(response);
        }         
    }
}
