
using Microsoft.AspNetCore.Mvc.Testing;

using RitoAPI.Services;

using Xunit;

namespace RitoAPI.Tests
{
	public class SpectatorServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public SpectatorServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetGameInfo_ShouldHaveSameGameIdAsATheFeaturedGame()
		{
			var service = (SpectatorService)_factory.Services.GetService(typeof(SpectatorService));
			var summonerService = (SummonerService)_factory.Services.GetService(typeof(SummonerService));
			var region = "euw1";
			var featuredGames = service.GetFeaturedGames(region);
			var expected = featuredGames.gameList[0].gameId;

			var activeSummonerName = featuredGames.gameList[0].participants[0].summonerName;
			var summoner = summonerService.GetSummonerByName(region, activeSummonerName);
			var gameInfo = service.GetGameInfo(region, summoner.Id);
			var actual = gameInfo.gameId;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetFeaturedGames_ShouldHaveFiveGames()
		{
			var expected = 5;
			
			var service = (SpectatorService)_factory.Services.GetService(typeof(SpectatorService));
			var featuredGames = service.GetFeaturedGames("euw1");
			var actual = featuredGames.gameList.Count;

			Assert.Equal(expected, actual);
		}
	}
}