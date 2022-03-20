using MVVMAnimeList.Models;
using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands
{
    public class LoadTrelloItemsCommand : AsyncCommandBase
    {
        private readonly TrelloListViewModel _trelloListViewModel;
        public LoadTrelloItemsCommand(TrelloListViewModel trelloListViewModel)
        {
            _trelloListViewModel = trelloListViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<TrelloItem> trelloItems = await _trelloListViewModel.GetAllItems();
            foreach(var item in trelloItems)
            {
                item.Tags = await _trelloListViewModel.GetTags(item);
                _trelloListViewModel.ListItem.Add(item);
            }
        }
    }
}
