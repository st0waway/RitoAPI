using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RitoAPI.Controllers
{
    [Route("champion-masteries")]
    [ApiController]
    public class ChampionMasteryController : ControllerBase
    {
        private readonly ChampionMasteryv4Repo _repository = new ChampionMasteryv4Repo();

        [HttpGet("by-summoner/{encryptedSummonerId}")]
        public ActionResult<List<ChampionMasteryDTO>> GetChampionMasteryBySummoner(string encryptedSummonerId)
        {
            var championMasteryList = _repository.GetChampionMasteryBySummoner(encryptedSummonerId);
            if (championMasteryList != null)
            {
                return Ok(championMasteryList);
            }
            else
            {
                return NotFound();
            }
        }
    }
}