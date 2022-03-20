using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloAllTagsProvider
{
    public interface ITrelloAllTagsProvider
    {
        Task<IEnumerable<Tag>> GetTags();
    }
}
