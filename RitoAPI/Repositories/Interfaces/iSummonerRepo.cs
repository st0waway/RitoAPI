using RitoAPI.Models;

namespace RitoAPI.Repositories
{
    interface iSummonerRepo
    {
        SummonerDTO GetSummonerByName(string userid);
        SummonerDTO GetSummonerByAccount(string encryptedAccountId);
        SummonerDTO GetSummonerByPUUID(string encryptedPUUID);
        SummonerDTO GetSummonerBySummonerID(string encryptedSummonerId);
    }
}
