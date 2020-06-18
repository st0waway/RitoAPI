using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("summoner")]
    [ApiController]
    public class Summonerv4Controller : ControllerBase
    {
        private readonly Summonerv4Repo _repository = new Summonerv4Repo();

        [HttpGet("{summonerName}")]
        public ActionResult<SummonerDTO> GetSummonerByName(string summonerName)
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
    }
}