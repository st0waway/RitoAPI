using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [ApiController]
    public class ChampionController : ControllerBase
    {
        private readonly ChampionRepo _repository;

        public ChampionController(ChampionRepo championRepo)
        {
            _repository = championRepo;
        }

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