using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands.TrelloTags
{
    public class AddTrelloTagCommand : AsyncCommandBase
    {
        private readonly TrelloListViewModel _trelloListViewModel;

        public AddTrelloTagCommand(TrelloListViewModel trelloListViewModel)
        {
            _trelloListViewModel = trelloListViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await _trelloListViewModel.AddTagItem();
        }
    }
}
