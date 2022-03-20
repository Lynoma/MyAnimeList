using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloTagCreator
{
    public interface ITrelloTagCreator
    {
        public Task CreateItem(TrelloItem trelloItem, Tag tag);
    }
}
