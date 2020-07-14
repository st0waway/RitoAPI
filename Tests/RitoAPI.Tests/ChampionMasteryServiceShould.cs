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
		public void GetChampionMasteryById()
		{
			var service = (ChampionMasteryService)_factory.Services.GetService(typeof(ChampionMasteryService));
			var championMasteries = service.GetChampionMasteryById("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk");
			Assert.Equal("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", championMasteries[0].summonerId);
			Assert.Equal("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", championMasteries[5].summonerId);
			Assert.Equal("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", championMasteries[10].summonerId);
			Assert.Equal("ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", championMasteries[50].summonerId);
		}
	}
}
