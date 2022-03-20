using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloItemProviders
{
    public interface ITrelloItemProvider
    {
        Task<IEnumerable<TrelloItem>> GetAllTrelloItems(int idList);
    }
}
