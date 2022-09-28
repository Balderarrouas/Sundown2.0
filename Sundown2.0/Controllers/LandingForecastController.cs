using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sundown2._0.Models;
using Sundown2._0.Services;
using System.Globalization;
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
        private readonly ISpaceStationService _spaceStationService;

        public LandingForecastController(ILogger<LandingForecastController> logger, 
            ILandingForecastService landingForecastService, ISpaceStationService spaceStationService)
        {
            _logger = logger;
            _landingForecastService = landingForecastService;
            _spaceStationService = spaceStationService;
        }

        [HttpGet]
        public async Task<ActionResult<LandingTime>> Get()
        {
            var closestLandingSite = await _spaceStationService.DetermineClosestLanding();


            var landingTime = await _landingForecastService.DetermineTimeOfLanding(closestLandingSite);
            var result = new LandingTime(landingTime, closestLandingSite);

            return Ok(result);
        }








    }
}
