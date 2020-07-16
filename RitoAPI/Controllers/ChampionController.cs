using Microsoft.AspNetCore.Mvc;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [ApiController]
    public class ChampionController : ControllerBase
    {
        private ChampionService _championService;

        public ChampionController(ChampionService championService)
        {
            _championService = championService;
        }

        [HttpGet("champion-rotations/{region}")]
        public IActionResult GetFreeChampionInfo(string region = "euw1")
        {
            {
                var freeChampRotation = _championService.GetFreeChampionInfo(region);

                if (freeChampRotation == null)
                {
                    return BadRequest();
                }

                return Ok(freeChampRotation);
            }
        }
    }
}