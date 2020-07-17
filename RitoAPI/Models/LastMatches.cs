using System.Collections.Generic;

namespace RitoAPI.Models
{
	public class LastMatches
	{
		public string summonerName { get; set; }
		public List<string> time { get; set; }
		public List<bool> victory { get; set; }
	}
}
