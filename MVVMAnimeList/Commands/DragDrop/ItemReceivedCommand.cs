using MVVMAnimeList.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands
{
    public class ItemReceivedCommand : AsyncCommandBase
    {
        private readonly TrelloListViewModel _trelloListViewModel;

        public ItemReceivedCommand(TrelloListViewModel trelloListViewModel)
        {
            _trelloListViewModel = trelloListViewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            if (!_trelloListViewModel.ListItem.Contains(_trelloListViewModel.IncomingItem))
            {
                _trelloListViewModel.IncomingItem.id_list = _trelloListViewModel._listId;
                _trelloListViewModel.ListItem.Add(_trelloListViewModel.IncomingItem);
                await _trelloListViewModel.UpdateList();
            }
        }
    }
}
