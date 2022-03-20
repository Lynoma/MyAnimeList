using MVVMAnimeList.Models;
using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloItemUpdaters
{
    public interface ITrelloItemUpdater
    {
        Task UpdateTrelloItem(TrelloListViewModel trelloListViewModel, int idList);
    }
}
