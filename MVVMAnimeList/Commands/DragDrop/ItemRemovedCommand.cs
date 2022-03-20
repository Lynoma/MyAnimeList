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
    public class ItemRemovedCommand : CommandBase
    {
        private readonly TrelloListViewModel _trelloListViewModel;

        public ItemRemovedCommand(TrelloListViewModel trelloListViewModel)
        {
            _trelloListViewModel = trelloListViewModel;
        }

        public override void Execute(object parameter)
        {
            _trelloListViewModel.ListItem.Remove(_trelloListViewModel.RemovedItem);
        }
    }
}
