﻿using RitoAPI.Models;
using Microsoft.Extensions.Options;
using RitoAPI.Repositories.Interfaces;

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
