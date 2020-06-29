using RitoAPI.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace RitoAPI.Repositories
{
    public class SummonerRepo : iSummonerRepo
    {
        private readonly string _apiKey;        

        public SummonerRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        } 
    }
}
