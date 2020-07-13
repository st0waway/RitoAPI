using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
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
        public ActionResult<ChampionInfo> GetFreeChampionInfo()
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