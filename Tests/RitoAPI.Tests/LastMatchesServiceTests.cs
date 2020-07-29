﻿using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Testing;

using RitoAPI.Services;

using Xunit;

namespace RitoAPI.Tests
{
	public class LastMatchesServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public LastMatchesServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("euw1", "Lum1x")]
		[InlineData("na1", "C9 Zven")]
		[InlineData("ru", "Yu meng")]
		[InlineData("jp1", "biewanad")]
		[InlineData("kr", "T1 BurdoI")]
		public void GetLastMatchesBySummoner_ReturnsCorrectSummonerName(string region, string summonerName )
		{
			var expected = summonerName;
			var service = (LastMatchesService)_factory.Services.GetService(typeof(LastMatchesService));
			var lastMatchesInfo = service.GetLastMatchesBySummoner(region, summonerName);
			var actual = lastMatchesInfo.summonerName;
			
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetMatchesForMultipleSummoners()
		{
			var service = (LastMatchesService)_factory.Services.GetService(typeof(LastMatchesService));
			var summonerNames = new List<string> {"Lum1x", "Dimodead"};
			var lastMatchesInfo = service.GetMatchesForMultipleSummoners("euw1", summonerNames);
			Assert.Equal("Lum1x", lastMatchesInfo[0].summonerName);
			var index = 0;
			foreach (var summonerName in summonerNames)
			{
				Assert.Equal(summonerName, lastMatchesInfo[index].summonerName);
				index++;
			}
		}
	}
}