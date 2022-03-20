using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Models
{
    public class AnimeItem
    {
        public int mal_id { get; set; }

        public string url { get; set; }

        public string image_url { get; set; }

        public string title { get; set; }

        public bool airing { get; set; }

        public string synopsys { get; set; }

        public string type { get; set; }

        public string episodes { get; set; }

        public float score { get; set; }

        public string start_date { get; set; }

        public string end_date { get; set; }

        public int members { get; set; }

        public string rated { get; set; }
    }
}
