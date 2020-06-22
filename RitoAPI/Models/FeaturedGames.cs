using System.Collections.Generic;

namespace RitoAPI.Models
{
    public class FeaturedGames
    {
        public List<FeaturedGameInfo> gameList { get; set; }
        public long clientRefreshInterval { get; set; }
    }

    public class FeaturedGameInfo
    {
        public string gameMode { get; set; }
        public long gameLength { get; set; }
        public long mapId { get; set; }
        public string gameType { get; set; }
        public List<BannedChampion> bannedChampions { get; set; }
        public long gameId { get; set; }
        public Observer observers { get; set; }
        public long gameQueueConfigId { get; set; }
        public long gameStartTime { get; set; }
        public List<Participant> participants { get; set; }
        public string platformId { get; set; }
    }
}
