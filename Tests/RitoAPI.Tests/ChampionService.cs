using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class ChampionServiceShould : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public ChampionServiceShould(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetFreeChampionInfo()
		{
			var service = (ChampionService)_factory.Services.GetService(typeof(ChampionService));
			var freeChampionRotation = service.GetFreeChampionInfo();
			Assert.IsType<ChampionInfo>(freeChampionRotation);
			Assert.Equal(15, freeChampionRotation.freeChampionIds.Count);
			Assert.Equal(10, freeChampionRotation.freeChampionIdsForNewPlayers.Count);
			Assert.Equal(10, freeChampionRotation.maxNewPlayerLevel);
		}
	}
}
