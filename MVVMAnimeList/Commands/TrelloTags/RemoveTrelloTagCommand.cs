using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands.TrelloTags
{
    public class RemoveTrelloTagCommand : AsyncCommandBase
    {
        private readonly TrelloListViewModel _trelloListViewModel;

        public RemoveTrelloTagCommand(TrelloListViewModel trelloListViewModel)
        {
            _trelloListViewModel = trelloListViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await _trelloListViewModel.RemoveTagItem();
        }
    }
}
