using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloTagProvider
{
    public interface ItrelloTagProvider
    {
        Task<IEnumerable<TagDTO>> GetTags(TrelloItem item);
    }
}
