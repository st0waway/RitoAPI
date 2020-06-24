using RitoAPI.Models;

namespace RitoAPI.Repositories
{
    interface iSpectatorRepo
    {
        CurrentGameInfo GetGameInfo(string encryptedSummonerId);
        FeaturedGameInfo GetFeaturedGames();
    }
}
