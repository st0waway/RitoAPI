using System.Collections.Generic;

namespace RitoAPI.Models
{
    public class Message
    {
        public string severity { get; set; }
        public string updated_at { get; set; }
        public string author { get; set; }
        public List<Translation> translations { get; set; }
        public string created_at { get; set; }
        public string id { get; set; }
        public string content { get; set; }
    }
}
