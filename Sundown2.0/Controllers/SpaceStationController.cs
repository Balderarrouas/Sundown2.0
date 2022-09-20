using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sundown2._0.Entities;
using Sundown2._0.Services;
using System.Threading.Tasks;

namespace Sundown2._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]    
    public class SpaceStationController : ControllerBase
    {
        private readonly ILogger<SpaceStationController> _logger;
        private readonly ISpaceStationService _spaceStationService;

        public SpaceStationController(ILogger<SpaceStationController> logger, ISpaceStationService spaceStationService) 
        {
            _logger = logger;
            _spaceStationService = spaceStationService;
        }


        
        [HttpGet]
        public async Task<ActionResult<ClosestLandingFacility>> Get()
        {
            var result = await _spaceStationService.Get();

            return Ok(result);
        }

    }
}
