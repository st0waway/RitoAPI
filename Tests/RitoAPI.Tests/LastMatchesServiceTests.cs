using System.Collections;
using System.Collections.Generic;

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
		public void GetLastMatchesBySummoner_ReturnsCorrectSummonerName(string region, string summonerName)
		{
			var expected = summonerName;
			var service = (LastMatchesService)_factory.Services.GetService(typeof(LastMatchesService));
			var lastMatchesInfo = service.GetLastMatchesBySummoner(region, summonerName);
			var actual = lastMatchesInfo.summonerName;

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("euw1", "Lum1x", "Dimodead")]
		public void GetMatchesForMultipleSummoners_ReturnsCorrectSummonerName(string region, string summonerName1, string summonerName2)
		{
			var service = (LastMatchesService)_factory.Services.GetService(typeof(LastMatchesService));
			var summonerNames = new List<string> { summonerName1, summonerName2 };
			var lastMatchesInfo = service.GetMatchesForMultipleSummoners(region, summonerNames);
			var index = 0;
			foreach (var summonerName in summonerNames)
			{
				Assert.Equal(summonerName, lastMatchesInfo[index].summonerName);
				index++;
			}
		}

		[Theory, ClassData(typeof(SummonerNamesData))]
		public void GetMatchesForMultipleSummoners_UsingClassData(string region, string summonerName1, string summonerName2)
		{
			var service = (LastMatchesService)_factory.Services.GetService(typeof(LastMatchesService));
			var summonerNames = new List<string> { summonerName1, summonerName2 };
			var lastMatchesInfo = service.GetMatchesForMultipleSummoners(region, summonerNames);
			var index = 0;
			foreach (var summonerName in summonerNames)
			{
				Assert.Equal(summonerName, lastMatchesInfo[index].summonerName);
				index++;
			}
		}

		public class SummonerNamesData : IEnumerable<object[]>
		{
			private readonly List<object[]> _summonerNames = new List<object[]>()
			{
				new object[] {"euw1", "Lum1x", "Dimodead" },
				new object[] {"euw1", "Spb Taipan", "HydroPat" }
			};

			public IEnumerator<object[]> GetEnumerator()
			{
				return _summonerNames.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
	}
}
