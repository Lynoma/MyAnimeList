using MVVMAnimeList.DbContexts;
using MVVMAnimeList.Store;
using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands
{
    public class NavigateDetailsCommand : AsyncCommandBase
    {
        private readonly SearchPageViewModel _searchPageViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public NavigateDetailsCommand(NavigationStore navigationStore, SearchPageViewModel searchPageViewModel, AnimeListDbContextFactory animeListDbContextFactory)
        {
            _navigationStore = navigationStore;
            _searchPageViewModel = searchPageViewModel;
            _animeListDbContextFactory = animeListDbContextFactory;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _navigationStore.CurrentViewModel = await DetailsPageViewModel.LoadPage(_searchPageViewModel.SelectionChanged, _animeListDbContextFactory);
        }
    }
}
