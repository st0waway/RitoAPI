using RitoAPI.Models;

namespace RitoAPI.Repositories
{
    interface iSummonerRepo
    {   
        SummonerDTO GetSummonerBySummonerID(string encryptedSummonerId);
    }
}
