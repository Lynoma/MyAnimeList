using MVVMAnimeList.Models;
using MVVMAnimeList.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands
{
    public class DeleteTrelloItemsCommand : CommandBase
    {
        private readonly TrelloListViewModel _trelloListViewModel;
        public DeleteTrelloItemsCommand(TrelloListViewModel trelloListViewModel)
        {
            _trelloListViewModel = trelloListViewModel;
        }
        public override async void Execute(object parameter)
        {
            if(parameter != null)
            {
                _trelloListViewModel.ListItem.Remove((TrelloItem)parameter);
                await _trelloListViewModel.DeleteItem((TrelloItem)parameter);
            }
        }
    }
}
