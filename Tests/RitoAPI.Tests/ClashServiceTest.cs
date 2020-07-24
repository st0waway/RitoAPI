using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class ClashServiceTest : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public ClashServiceTest(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetActiveClashPlayers()
		{
			var service = (ClashService)_factory.Services.GetService(typeof(ClashService));
			var summoner = service.GetActiveClashPlayers("euw1", "hww71nGe9ugELSlk19keIQtTCsjb5GkkWfTjzw66l1g8opQ"); //need an active clash summoner id
			Assert.IsType<List<ClashPlayerDto>>(summoner);
		}
	}
}