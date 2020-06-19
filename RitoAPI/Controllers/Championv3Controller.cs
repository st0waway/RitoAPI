using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [ApiController]
    public class Championv3Controller : ControllerBase
    {
        private readonly Championv3Repo _repository = new Championv3Repo();

        [HttpGet("champion-rotations")]
        public ActionResult<ChampionInfo> GetChampionInfo()
        {
            var championInfo = _repository.GetChampionInfo();
            if (championInfo != null)
            {
                return Ok(championInfo);
            }
            else
            {
                return NotFound();
            }
        }
    }
}