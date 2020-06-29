using Microsoft.Extensions.Options;
using RitoAPI.Models;
using RitoAPI.Repositories.Interfaces;

namespace RitoAPI.Repositories
{
    public class SpectatorRepo : iSpectatorRepo

    {
        private readonly string _apiKey;

        public SpectatorRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
    }
}
