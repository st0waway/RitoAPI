using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class ChampionMasteryServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public ChampionMasteryServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("euw1", "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")]
		[InlineData("na1", "R84hfPnFbZbisUxqc75-e4dxzIS99ExnjqACgn7b5xzN1E0")]
		[InlineData("ru", "N8kT7Dgjk2_AGCznbanIkSRtRF9U_g3oRCn3BHO-zsWBVwg")]
		[InlineData("oc1", "ySQv_pKT-lhCNa-0Swb_Gm7-s7vkTpOCkPZ7QZubHJqq")]
		[InlineData("jp1", "v7KFUgdLNT49aR6vVyO2zOxbab_INOUwWkOpMJElPYTdPTY")]
		public void GetChampionsMasteryById_ReturnsInfoForCorrectId(string region, string summonerId)
		{
			var expected = summonerId;

			var service = (ChampionMasteryService)_factory.Services.GetService(typeof(ChampionMasteryService));
			var championMasteryList = service.GetChampionsMasteryById(region, summonerId);
			var actual = championMasteryList[0].summonerId;
			
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("euw1", "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", 1)]
		[InlineData("na1", "R84hfPnFbZbisUxqc75-e4dxzIS99ExnjqACgn7b5xzN1E0", 1)]
		[InlineData("ru", "N8kT7Dgjk2_AGCznbanIkSRtRF9U_g3oRCn3BHO-zsWBVwg", 1)]
		[InlineData("oc1", "ySQv_pKT-lhCNa-0Swb_Gm7-s7vkTpOCkPZ7QZubHJqq", 5)]
		[InlineData("jp1", "v7KFUgdLNT49aR6vVyO2zOxbab_INOUwWkOpMJElPYTdPTY", 1)]
		public void GetChampionMasteryByIdandChampionId_ReturnsDataForCorrectChampion(string region, string summonerId, int championId)
		{
			var expected = championId;

			var service = (ChampionMasteryService)_factory.Services.GetService(typeof(ChampionMasteryService));
			var championMasteries = service.GetChampionMasteryByIdandChampionId(region, summonerId, championId);
			var actual = championMasteries.championId;
			
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("euw1", "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")]
		[InlineData("na1", "R84hfPnFbZbisUxqc75-e4dxzIS99ExnjqACgn7b5xzN1E0")]
		[InlineData("ru", "N8kT7Dgjk2_AGCznbanIkSRtRF9U_g3oRCn3BHO-zsWBVwg")]
		[InlineData("oc1", "ySQv_pKT-lhCNa-0Swb_Gm7-s7vkTpOCkPZ7QZubHJqq")]
		[InlineData("jp1", "v7KFUgdLNT49aR6vVyO2zOxbab_INOUwWkOpMJElPYTdPTY")]
		public void GetChampionMasteryScore_ReturnsMasteryScoreGreaterThanFive(string region, string summonerId)
		{
			var service = (ChampionMasteryService)_factory.Services.GetService(typeof(ChampionMasteryService));
			var championMasteryLevel = service.GetChampionMasteryScore(region, summonerId);
			var actual = championMasteryLevel;

			Assert.True(actual > 5);
		}
	}
}
