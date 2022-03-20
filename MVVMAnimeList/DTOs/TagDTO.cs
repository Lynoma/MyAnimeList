using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.DTOs
{
    public class TagDTO
    {
        [Key]
        public int tag_id { get; set; }
        public string name { get; set; }
        public string color { get; set; }

    }
}
