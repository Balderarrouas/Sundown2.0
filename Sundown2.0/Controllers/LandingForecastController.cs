using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sundown2._0.Models;
using Sundown2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]    
    public class LandingForecastController : ControllerBase
    {


        private readonly ILogger<LandingForecastController> _logger;
        private readonly ILandingForecastService _landingForecastService;

        public LandingForecastController(ILogger<LandingForecastController> logger, ILandingForecastService landingForecastService)
        {
            _logger = logger;
            _landingForecastService = landingForecastService;
        }

        [HttpGet]
        public async Task<ActionResult<LandingTime>> Get()
        {
            var result = await _landingForecastService.Get();

            return Ok(result);
        }








    }
}
