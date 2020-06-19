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
        private readonly ChampionMasteryv4Repo _repository;

        public ChampionMasteryController(ChampionMasteryv4Repo championMasteryv4Repo)
        {
            _repository = championMasteryv4Repo;
        }

        [HttpGet("by-summoner/{encryptedSummonerId}")]
        public ActionResult<List<ChampionMasteryDTO>> GetChamcpionMasteryBySummoner(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
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
        public ActionResult<ChampionMasteryDTO> GetChampionMasteryByPlayerIDandChampionID(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", long championId = 1)
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
        [HttpGet("scores/{encryptedSummonerId}")]
        public ActionResult<int> GetChampionMasteryScore(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
        {
            var championMasteryScore = _repository.GetChampionMasteryScore(encryptedSummonerId);
            if (championMasteryScore != 0)
            {
                return Ok(championMasteryScore);
            }
            else
            {
                return NotFound();
            }
        }
    }   
}