using MVVMAnimeList.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands
{
    public class SearchCommand : CommandBase
    {
        private readonly SearchPageViewModel _searchPageViewModel;

        public SearchCommand(SearchPageViewModel searchPageViewModel)
        {
            _searchPageViewModel = searchPageViewModel;
        }

        public override async void Execute(object parameter)
        {
            await _searchPageViewModel.SearchAPI();
        }
    }
}
