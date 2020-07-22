using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RitoAPI.Services;

namespace RitoAPI.Controllers
{
	[ApiController]
	public class ChampionController : ControllerBase
	{
		private ChampionService _championService;
		private readonly ILogger<ChampionController> _logger;

		public ChampionController(ChampionService championService, ILogger<ChampionController> logger)
		{
			_championService = championService;
			_logger = logger;
		}

		[HttpGet("champion-rotations/{region}")]
		public IActionResult GetFreeChampionInfo(string region = "euw1")
		{
			_logger.LogInformation("GetFreeChampionInfo, region = {region}", region);
			var freeChampRotation = _championService.GetFreeChampionInfo(region);

			if (freeChampRotation == null)
			{
				return BadRequest();
			}

			return Ok(freeChampRotation);
		}
	}
}