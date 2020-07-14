using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class ChampionMasteryServiceShould : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public ChampionMasteryServiceShould(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetChampionsMasteryById()
		{
			var service = (ChampionMasteryService)_factory.Services.GetService(typeof(ChampionMasteryService));
			var championMasteryList = service.GetChampionsMasteryById("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk");
			Assert.Equal("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", championMasteryList[0].summonerId);
			Assert.Equal("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", championMasteryList[5].summonerId);
			Assert.Equal("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", championMasteryList[10].summonerId);
			Assert.Equal("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", championMasteryList[50].summonerId);
		}

		[Fact]
		public void GetChampionMasteryByIdandChampionId()
		{
			var service = (ChampionMasteryService)_factory.Services.GetService(typeof(ChampionMasteryService));
			var championMasteries = service.GetChampionMasteryByIdandChampionId("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", 1);
			Assert.Equal("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", championMasteries.summonerId);
			Assert.Equal(1, championMasteries.championId);
		}

		[Fact]
		public void GetChampionMasteryScore()
		{
			var service = (ChampionMasteryService)_factory.Services.GetService(typeof(ChampionMasteryService));
			var championMasteryLevel = service.GetChampionMasteryScore("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk");
			Assert.IsType<int>(championMasteryLevel);
		}
	}
}
