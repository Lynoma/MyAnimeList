using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.DTOs
{
    public class TrelloItemDTO
    {
        [Key]
        public int mal_id { get; set; }
        public string? title { get; set; }
        public int id_list { get; set; }
    }
}
