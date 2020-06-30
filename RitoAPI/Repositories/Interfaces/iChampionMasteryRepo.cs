using RitoAPI.Models;
using System.Collections.Generic;

namespace RitoAPI.Repositories.Interfaces
{
    interface iChampionMasteryRepo
    {
        List<ChampionMasteryDTO> GetChampionMasteryBySummoner(string encryptedSummonerId); 
    }
}
