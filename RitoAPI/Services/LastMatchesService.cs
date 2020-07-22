
using Microsoft.Extensions.Options;
using RitoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RitoAPI.Services
{
	public class LastMatchesService
	{
		private readonly string _apiKey;
		private SummonerService _summonerService;
		private MatchService _matchService;

		public LastMatchesService(IOptions<UserConfig> userConfigAccessor, SummonerService summonerService, MatchService matchService)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
			_summonerService = summonerService;
			_matchService = matchService;
		}

		public LastMatches GetLastMatchesBySummoner(string region, string summonerName)
		{
			var summoner = _summonerService.GetSummonerByName(region, summonerName);
			var matches = _matchService.GetMatchlistByAccountId(region, summoner.AccountId);
			var lastFiveMatchIds = matches.matches.Take(5).Select(x => x.gameId).ToList();
			var wins = new List<bool>();
			var time = new List<string>();

			foreach (var matchId in lastFiveMatchIds)
			{
				var match = _matchService.GetMatchByMatchId(region, matchId.ToString());
				var playerId = match.participantIdentities.Where(x => x.player.currentAccountId == summoner.AccountId).Select(x => x.participantId);
				var win = match.participants[playerId.FirstOrDefault() - 1].stats.win;
				var gameEndTime = UnixTimeStampToDateTime(match.gameCreation, match.gameDuration);
				wins.Add(win);
				time.Add(gameEndTime.ToString());
			}

			var lastMatches = new LastMatches
			{
				summonerName = summonerName,
				victory = wins,
				time = time
			};


			return lastMatches;
		}

		public List<LastMatches> GetMatchesForMultipleSummoners(string region, List<string> summonerNames)
		{
			var multipleMatches = new List<LastMatches>();
			foreach (var summonerName in summonerNames)
			{
				var summonerMatches = GetLastMatchesBySummoner(region, summonerName);
				multipleMatches.Add(summonerMatches);
			}

			return multipleMatches;
		}		

		public static DateTime UnixTimeStampToDateTime(double gameCreation, double gameDuration)
		{			
			var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			var gameCreationTime = dtDateTime.AddMilliseconds(gameCreation).ToLocalTime();
			var gameEndTime = gameCreationTime.AddSeconds(gameDuration).ToLocalTime();
			return gameEndTime;
		}
	}



}