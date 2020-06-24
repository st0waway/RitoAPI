using RitoAPI.Models;
using System.Collections.Generic;

namespace RitoAPI.Repositories
{
    interface iChampionMasteryRepo
    {
        List<ChampionMasteryDTO> GetChampionMasteryBySummoner(string encryptedSummonerId);
        ChampionMasteryDTO GetChampionMasteryByPlayerIDandChampionID(string encryptedSummonerId, long championId);
        int GetChampionMasteryScore(string encryptedSummonerId);
    }
}
