using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("summoner")]
    [ApiController]
    public class Summonerv4Controller : ControllerBase
    {
        private readonly Summonerv4Repo _repository;

        public Summonerv4Controller(Summonerv4Repo summonerv4Repo)
        {
            _repository = summonerv4Repo;
        }

        [HttpGet("by-name/{summonerName}")]
        public ActionResult<SummonerDTO> GetSummonerByName(string summonerName = "Lum1x")
        {
            var summoner = _repository.GetSummonerByName(summonerName);
            if (summoner.Name != null)           
            {
                return Ok(summoner);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("by-account/{encryptedAccountId}")]
        public ActionResult<SummonerDTO> GetSummonerByAccount(string encryptedAccountId = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
        {
            var summoner = _repository.GetSummonerByAccount(encryptedAccountId);
            if (summoner.Name != null)
            {
                return Ok(summoner);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("by-puuid/{encryptedPUUID}")]
        public ActionResult<SummonerDTO> GetSummonerByPUUID(string encryptedPUUID = "6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA")
        {
            var summoner = _repository.GetSummonerByPUUID(encryptedPUUID);
            if (summoner.Name != null)
            {
                return Ok(summoner);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{encryptedSummonerId}")]
        public ActionResult<SummonerDTO> GetSummonerBySummonerID(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
        {
            var summoner = _repository.GetSummonerBySummonerID(encryptedSummonerId);
            if (summoner.Name != null)
            {
                return Ok(summoner);
            }
            else
            {
                return NotFound();
            }
        }
    }
}