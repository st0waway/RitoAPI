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

        [HttpGet("champion-rotations")]
        public IActionResult GetFreeChampionInfo()
        {
            {
                var freeChampRotation = _championService.GetFreeChampionInfo();

                if (freeChampRotation == null)
                {
                    return BadRequest();
                }

                return Ok(freeChampRotation);
            }
        }
    }
}