using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Models
{
    public class TrelloItem
    {
        public ObservableCollection<Tag> Tags;
        public int mal_id { get; set; }
        public string? title { get; set; }
        public int id_list { get; set; }

        public TrelloItem()
        {
            Tags = new ObservableCollection<Tag>();
        }
    }
}
