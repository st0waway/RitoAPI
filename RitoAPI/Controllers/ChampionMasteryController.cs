using Microsoft.AspNetCore.Mvc;
using RitoAPI.Services;
using System;
using System.IO;

namespace RitoAPI.Controllers
{
	[Route("champion-masteries")]
	[ApiController]
	public class ChampionMasteryController : ControllerBase
	{
		private ChampionMasteryService _championMasteryService;

		public ChampionMasteryController(ChampionMasteryService championMasteryService)
		{
			_championMasteryService = championMasteryService;
		}

		[HttpGet("by-id/{id}/{region}")]
		public IActionResult GetChampionsMasteryById(string region = "euw1", string id = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
		{
			var championMasteries = _championMasteryService.GetChampionsMasteryById(region, id);

			if (championMasteries == null)
			{
				return BadRequest();
			}

			return Ok(championMasteries);
		}

		[HttpGet("by-summoner/{encryptedSummonerId}/by-champion/{championId}/{region}")]
		public IActionResult GetChampionMasteryByIdandChampionId(string region = "euw1", string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", long championId = 1)
		{
			var championMastery = _championMasteryService.GetChampionMasteryByIdandChampionId(region, encryptedSummonerId, championId);

			if (championMastery == null)
			{
				return BadRequest();
			}

			return Ok(championMastery);
		}

		[HttpGet("scores/{encryptedSummonerId}/{region}")]
		public IActionResult GetChampionMasteryScore(string region = "euw1", string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
		{
			try
			{
				var championMasteryScore = _championMasteryService.GetChampionMasteryScore(region, encryptedSummonerId);
				return Ok(championMasteryScore);
			}
			catch (InvalidDataException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}
	}
}
