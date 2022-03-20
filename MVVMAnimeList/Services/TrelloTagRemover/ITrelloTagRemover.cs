using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloTagRemover
{
    public interface ITrelloTagRemover
    {
        public Task RemoveItem(TrelloItem trelloItem, Tag tag);
    }
}
