using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.DTOs
{
    public class TrelloItemTagDTO
    {
        [Key]
        public int trelloItem_tag_id { get; set; }

        public virtual TagDTO tagDto { get; set; }
        public virtual TrelloItemDTO trelloItemDto { get; set; }
    }
}
