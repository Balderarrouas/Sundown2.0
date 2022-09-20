using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sundown2._0.Models;
using Sundown2._0.Services;

namespace Sundown2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MissionImageController : ControllerBase
    {

        private readonly IMissionImageService _missionImageService;

        public MissionImageController(IMissionImageService missionImageService)
        {
            _missionImageService = missionImageService;
        }


        
        [HttpPost("create")]
        public IActionResult Create([FromForm]MissionImageDTO model)
        {

            var response = _missionImageService.Create(model);

            return Ok(response);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var response = _missionImageService.GetAll();

            return Ok(response);
        }


        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _missionImageService.GetById(id);

            return Ok(response);
        }

        
        [HttpPut("update/{id}")]
        public IActionResult Update([FromForm]MissionImageDTO model, int id)
        {
            var response = _missionImageService.Update(model, id);

            return Ok(response);
        }

        
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _missionImageService.Delete(id);

            return Ok(response);
        }
    }
}
