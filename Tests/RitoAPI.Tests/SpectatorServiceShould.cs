using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class SpectatorServiceShould : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public SpectatorServiceShould(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetGameInfo()
		{
			//var service = (SpectatorService)_factory.Services.GetService(typeof(SpectatorService));
			//var summoner = service.GetGameInfo();			
		}

		[Fact]
		public void GetFeaturedGames()
		{
			var service = (SpectatorService)_factory.Services.GetService(typeof(SpectatorService));
			var featuredGames = service.GetFeaturedGames();
			Assert.IsType<FeaturedGames>(featuredGames);
			Assert.Equal(5, featuredGames.gameList.Count);
		}
	}
}