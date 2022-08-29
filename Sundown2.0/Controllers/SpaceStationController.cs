using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sundown2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<string> Get(string timestamp)
        {
            return await _spaceStationService.Get(timestamp);
        }

    }
}
