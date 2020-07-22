using Microsoft.AspNetCore.Mvc;
using RitoAPI.Services;
using Microsoft.Extensions.Logging;

namespace RitoAPI.Controllers
{
	[Route("summoner")]
	[ApiController]
	public class SummonerController : ControllerBase
	{
		private SummonerService _summonerService;
		private readonly ILogger<SummonerController> _logger;

		public SummonerController(SummonerService summonerService, ILogger<SummonerController> logger)
		{
			_summonerService = summonerService;
			_logger = logger;
		}

		[HttpGet("name/{name}/{region}")]
		public IActionResult GetSummonerByName(string region = "euw1", string name = "Lum1x")
		{
			_logger.LogInformation("GetSummonerByName, region = {region}, name = {name}", region, name);
			var summoner = _summonerService.GetSummonerByName(region, name);

			if (summoner == null)
			{				
				return BadRequest();
			}
			
			return Ok(summoner);
		}

		[HttpGet("accountId/{accountId}/{region}")]
		public IActionResult GetSummonerByAccount(string region = "euw1", string accountId = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
		{
			_logger.LogInformation("GetSummonerByAccount, region = {region}, accountId = {accountId}", region, accountId);
			var summoner = _summonerService.GetSummonerByAccount(region, accountId);

			if (summoner == null)
			{
				return BadRequest();
			}

			return Ok(summoner);
		}

		[HttpGet("puuid/{puuid}/{region}")]
		public IActionResult GetSummonerByPUUID(string region = "euw1", string puuid = "6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA")
		{
			_logger.LogInformation("GetSummonerByPUUID, region = {region}, puuid = {puuid}", region, puuid);
			var summoner = _summonerService.GetSummonerByPUUID(region, puuid);

			if (summoner == null)
			{
				return BadRequest();
			}

			return Ok(summoner);
		}

		[HttpGet("id/{id}/{region}")]
		public IActionResult GetSummonerBySummonerID(string region = "euw1", string id = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
		{
			_logger.LogInformation("GetSummonerBySummonerID, region = {region}, id = {id}", region, id);
			var summoner = _summonerService.GetSummonerBySummonerID(region, id);

			if (summoner == null)
			{
				return BadRequest();
			}

			return Ok(summoner);
		}
	}
}