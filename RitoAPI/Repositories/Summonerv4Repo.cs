﻿using RitoAPI.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace RitoAPI.Repositories
{
    public class Summonerv4Repo : iSummonerv4Repo
    {
        private readonly string _apiKey;        

        public Summonerv4Repo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
                
        public SummonerDTO GetSummonerByName(string userid)
        {            
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + userid + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var summonerAsJson = sr.ReadToEnd();
                    var summoner = JsonConvert.DeserializeObject<SummonerDTO>(summonerAsJson);
                    return summoner;
                }
            }
        }

        public SummonerDTO GetSummonerByAccount(string encryptedAccountId)
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-account/" + encryptedAccountId + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var summonerAsJson = sr.ReadToEnd();
                    var summoner = JsonConvert.DeserializeObject<SummonerDTO>(summonerAsJson);
                    return summoner;
                }
            }
        }

        public SummonerDTO GetSummonerByPUUID(string encryptedPUUID)
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/" + encryptedPUUID + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var summonerAsJson = sr.ReadToEnd();
                    var summoner = JsonConvert.DeserializeObject<SummonerDTO>(summonerAsJson);
                    return summoner;
                }
            }
        }

        public SummonerDTO GetSummonerBySummonerID(string encryptedSummonerId)
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/" + encryptedSummonerId + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var summonerAsJson = sr.ReadToEnd();
                    var summoner = JsonConvert.DeserializeObject<SummonerDTO>(summonerAsJson);
                    return summoner;
                }
            }
        }
    }
}
