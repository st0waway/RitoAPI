namespace RitoAPI.Models
{
    public class Participant
    {
        public bool bot { get; set; }
        public long spell2Id { get; set; }
        public long profileIconId { get; set; }
        public string summonerName { get; set; }
        public long championId { get; set; }
        public long teamId { get; set; }
        public long spell1Id { get; set; }
    }
}
