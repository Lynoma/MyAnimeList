using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Models
{
    public class AnimeByID
    {
        public string request_hash { get; set; }
        public bool request_cached { get; set; }
        public int request_cached_expiry { get; set; }
        public int mal_id { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string trailer_url { get; set; }
        public string title { get; set; }
        public string title_english { get; set; }
        public string title_japanese { get; set; }
        public string[] title_synonyms { get; set; }
        public string type { get; set; }
        public string source { get; set; }
        public int episodes { get; set; }
        public string status { get; set; }
        public bool airing { get; set; }
        public Object aired { get; set; }
    }
}
