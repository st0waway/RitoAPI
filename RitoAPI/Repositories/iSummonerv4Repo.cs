using RitoAPI.Models;

namespace RitoAPI.Repositories
{
    interface iSummonerv4Repo
    {
        SummonerDTO GetSummonerByName(string userid);
        SummonerDTO GetSummonerByAccount(string encryptedAccountId);
    }
}
