using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Models
{
    public class SearchAnime
    {
        private string _request_hash;

        public string request_hash
        {
            get { return _request_hash; }
            set { _request_hash = value; }
        }

        private bool _request_cached;

        public bool request_cached
        {
            get { return _request_cached; }
            set { _request_cached = value; }
        }

        private int _request_cache_expiry;

        public int request_cache_expiry
        {
            get { return _request_cache_expiry; }
            set { _request_cache_expiry = value; }
        }

        private List<AnimeItem> _results;

        public List<AnimeItem> results
        {
            get { return _results; }
            set { _results = value; }
        }

    }
}
