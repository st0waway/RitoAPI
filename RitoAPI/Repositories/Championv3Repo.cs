using Newtonsoft.Json;
using RitoAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RitoAPI.Repositories
{
    public class Championv3Repo: iChampionv3Repo
    {
        string apikey = "RGAPI-6bc0db09-5158-4b23-b364-7ec924315239";
        public ChampionInfo GetChampionInfo()
        {
            var url = "https://euw1.api.riotgames.com/lol/platform/v3/champion-rotations" + "?api_key=" + apikey;
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
