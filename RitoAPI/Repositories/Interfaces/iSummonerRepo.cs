using RitoAPI.Models;

namespace RitoAPI.Repositories
{
    interface iSummonerRepo
    {        
        SummonerDTO GetSummonerByPUUID(string encryptedPUUID);
        SummonerDTO GetSummonerBySummonerID(string encryptedSummonerId);
    }
}
