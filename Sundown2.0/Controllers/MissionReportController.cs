﻿using Microsoft.AspNetCore.Authorization;
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
        public IActionResult GetAll()
        {
            var response = _missionReportService.GetAll();

            return Ok(response);
        }

        
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _missionReportService.GetById(id);

            return Ok(response);
        }


        [HttpPut("update/{id}")]
        public IActionResult Update(MissionReportDTO model, int id)
        {          

            var response = _missionReportService.Update(model, id);

            return Ok(response);
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response =  _missionReportService.Delete(id);

            return Ok(response);
        }         
    }
}