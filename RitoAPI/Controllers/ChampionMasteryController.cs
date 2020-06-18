using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;
using System.Collections.Generic;

namespace RitoAPI.Controllers
{
    [Route("champion-masteries")]
    [ApiController]
    public class ChampionMasteryController : ControllerBase
    {
        private readonly ChampionMasteryv4Repo _repository = new ChampionMasteryv4Repo();

        [HttpGet("by-summoner/{encryptedSummonerId}")]
        public ActionResult<List<ChampionMasteryDTO>> GetChamcpionMasteryBySummoner(string encryptedSummonerId)
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

        [HttpGet("by-summoner/{encryptedSummonerId}/by-champion/{championId}")]
        public ActionResult<ChampionMasteryDTO> GetChampionMasteryByPlayerIDandChampionID(string encryptedSummonerId, long championId)
        {
            var championMastery = _repository.GetChampionMasteryByPlayerIDandChampionID(encryptedSummonerId, championId);
            if (championMastery != null)
            {
                return Ok(championMastery);
            }
            else
            {
                return NotFound();
            }
        }
    }
}