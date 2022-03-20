using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands
{
    public class AddTrelloItemCommand : AsyncCommandBase
    {
        private readonly DetailsPageViewModel _detailsPageViewModel;
        public AddTrelloItemCommand(DetailsPageViewModel detailsPageViewModel)
        {
            _detailsPageViewModel = detailsPageViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await _detailsPageViewModel.AddItem(); 
        }
    }
}
