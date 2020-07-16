using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class LeagueExpServiceShould : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public LeagueExpServiceShould(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetLeagueExp()
		{
			var service = (LeagueExpService)_factory.Services.GetService(typeof(LeagueExpService));
			var leagueQueueEntry = service.GetLeagueExp("euw1","RANKED_SOLO_5x5", "PLATINUM", "IV");
			Assert.IsType<List<LeagueEntryDTO>>(leagueQueueEntry);
			Assert.Equal("PLATINUM", leagueQueueEntry[0].tier);
			Assert.Equal("PLATINUM", leagueQueueEntry[5].tier);
			Assert.Equal("PLATINUM", leagueQueueEntry[12].tier);
		}
	}
}
