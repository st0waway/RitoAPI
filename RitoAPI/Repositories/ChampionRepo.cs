﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories.Interfaces;
using System.IO;
using System.Net;

namespace RitoAPI.Repositories
{
    public class ChampionRepo : iChampionRepo
    {
        private readonly string _apiKey;

        public ChampionRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }       
        public ChampionInfo GetChampionInfo()
        {
            var url = "https://euw1.api.riotgames.com/lol/platform/v3/champion-rotations" + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var championInfoJson = sr.ReadToEnd();
                    var championInfo = JsonConvert.DeserializeObject<ChampionInfo>(championInfoJson);
                    return championInfo;
                }
            }
        }
    }
}
