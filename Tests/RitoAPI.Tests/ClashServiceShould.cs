using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class ClashServiceShould : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public ClashServiceShould(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetActiveClashPlayers()
		{
			var service = (ClashService)_factory.Services.GetService(typeof(ClashService));
			var summoner = service.GetActiveClashPlayers("");
			Assert.IsType<List<ClashPlayerDto>>(summoner);
		}
	}
}