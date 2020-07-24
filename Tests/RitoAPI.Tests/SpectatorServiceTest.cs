using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class SpectatorServiceTest : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public SpectatorServiceTest(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetGameInfo()
		{
			var service = (SpectatorService)_factory.Services.GetService(typeof(SpectatorService));
			var summonerService = (SummonerService)_factory.Services.GetService(typeof(SummonerService));
			var featuredGames = service.GetFeaturedGames("euw1");
			var activeSummonerName = featuredGames.gameList[0].participants[0].summonerName;
			var summoner = summonerService.GetSummonerByName("euw1", activeSummonerName);
			var summonerId = summoner.Id;
			var gameInfo = service.GetGameInfo("euw1", summonerId);
			Assert.IsType<CurrentGameInfo>(gameInfo);
			Assert.Equal(featuredGames.gameList[0].gameId, gameInfo.gameId);
		}

		[Fact]
		public void GetFeaturedGames()
		{
			var service = (SpectatorService)_factory.Services.GetService(typeof(SpectatorService));
			var featuredGames = service.GetFeaturedGames("euw1");
			Assert.IsType<FeaturedGames>(featuredGames);
			Assert.Equal(5, featuredGames.gameList.Count);
		}
	}
}