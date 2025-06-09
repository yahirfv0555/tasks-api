using EarringsApi.Features.Draws.Models;
using EarringsApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EarringsApi.Features.Draws
{
    [EnableCors("AllowAnyOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DrawsController : Controller
    {
        private readonly DrawsRepository drawsRepository;

        public DrawsController() 
        {
            drawsRepository = new();
        }

        [HttpGet]
        public async Task<ActionResult<List<DrawDto>>> GetDraws([FromQuery] DrawFilter filter)
        {
            List<DrawDto> draws = await drawsRepository.GetDraws(filter);

            return Ok(draws);
        }

        [HttpPost]
        public async Task<ActionResult<Execution>> CreateDraw([FromBody] DrawDao draw)
        {
            Execution execution = await drawsRepository.CreateDraw(draw);

            return Ok(execution);
        }

        [HttpPut]
        public async Task<ActionResult<Execution>> UpdateDraw([FromBody] DrawDao draw)
        {
            Execution execution = await drawsRepository.UpdateDraw(draw);

            return Ok(execution);
        }

        [HttpDelete]
        public async Task<ActionResult<Execution>> DeleteDraw([FromBody] DrawFilter filter)
        {
            Execution execution = await drawsRepository.DeleteDraw(filter);

            return Ok(execution);
        }
    }
}
