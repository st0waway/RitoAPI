using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;
using RitoAPI.Services;
using System.IO;
using System.Net;

namespace RitoAPI.Controllers
{
	[Route("summoner")]
	[ApiController]
	public class SummonerController : ControllerBase
	{
		private SummonerService _summonerService;

		public SummonerController(SummonerService summonerService)
		{
			_summonerService = summonerService;
		}

		[HttpGet("name/{name}")]
		public IActionResult GetSummonerByName(string name = "Lum1x")
		{
			var summoner = _summonerService.GetSummonerByName(name);

			if (summoner == null)
			{
				return BadRequest();
			}

			return Ok(summoner);
		}

		[HttpGet("accountId/{accountId}")]
		public ActionResult<SummonerDTO> GetSummonerByAccount(string accountId = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
		{
			var summoner = _summonerService.GetSummonerByAccount(accountId);

			if (summoner == null)
			{
				return BadRequest();
			}

			return Ok(summoner);
		}

		[HttpGet("puuid/{puuid}")]
		public ActionResult<SummonerDTO> GetSummonerByPUUID(string puuid = "6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA")
		{
			var summoner = _summonerService.GetSummonerByPUUID(puuid);

			if (summoner == null)
			{
				return BadRequest();
			}

			return Ok(summoner);
		}

		[HttpGet("id/{id}")]
		public ActionResult<SummonerDTO> GetSummonerBySummonerID(string id = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
		{
			var summoner = _summonerService.GetSummonerBySummonerID(id);

			if (summoner == null)
			{
				return BadRequest();
			}

			return Ok(summoner);
		}
	}
}