using RitoAPI.Models;

namespace RitoAPI.Repositories
{
    interface iSpectatorv4Repo
    {
        CurrentGameInfo GetGameInfo(string encryptedSummonerId);
        FeaturedGameInfo GetFeaturedGames();
    }
}
