using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloItemCreators
{
    public interface ITrelloItemCreator
    {
        Task CreateItem(TrelloItem trelloItem);
    }
}
