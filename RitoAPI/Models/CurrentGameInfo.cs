using System.Collections.Generic;

namespace RitoAPI.Models
{
    public class CurrentGameInfo
    {
        public long gameId { get; set; }
        public string gameType { get; set; }
        public long gameStartTime { get; set; }
        public long mapId { get; set; }
        public long gameLength { get; set; }
        public string platformId { get; set; }
        public string gameMode { get; set; }
        public List<BannedChampion> bannedChampions { get; set; }
        public long gameQueueConfigId { get; set; }
        public Observer observers { get; set; }
        public List<CurrentGameParticipant> participants { get; set; }
    }

    public class BannedChampion
    {
        public int pickTurn { get; set; }
        public long championId { get; set; }
        public long teamId { get; set; }
    }

    public class Observer
    {
        public string encryptionKey { get; set; }
    }

    public class CurrentGameParticipant
    {
        public long championId { get; set; }
        public Perks perks { get; set; }
        public long profileIconId { get; set; }
        public bool bot { get; set; }
        public long teamId { get; set; }
        public string summonerName { get; set; }
        public string summonerId { get; set; }
        public long spell1Id { get; set; }
        public long spell2Id { get; set; }
        public List<GameCustomizationObject> gameCustomizationObjects { get; set; }
    }

    public class Perks
    {
        public List<long> perkIds { get; set; }
        public long perkStyle { get; set; }
        public long perkSubStyle { get; set; }
    }

    public class GameCustomizationObject
    {
        public string category { get; set; }
        public string content { get; set; }
    }
}
