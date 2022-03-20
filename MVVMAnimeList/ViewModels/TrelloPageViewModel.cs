using MVVMAnimeList.Commands;
using MVVMAnimeList.DbContexts;
using MVVMAnimeList.Services.TrelloItemCreators;
using MVVMAnimeList.Services.TrelloItemProviders;
using MVVMAnimeList.Store;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMAnimeList.ViewModels
{
    
    public class TrelloPageViewModel : ViewModelBase 
    {
        public TrelloListViewModel ToWatchViewModel { get; }
        public TrelloListViewModel WatchingViewModel { get; }
        public TrelloListViewModel WatchedViewModel { get; }
        public TrelloListViewModel StandByViewModel { get; }
        public TrelloListViewModel GiveUpViewModel { get; }
        public TrelloPageViewModel(AnimeListDbContextFactory animeListDbContextFactory)
        {
            ToWatchViewModel = TrelloListViewModel.LoadViewModel(1, animeListDbContextFactory);
            WatchingViewModel = TrelloListViewModel.LoadViewModel(2, animeListDbContextFactory);
            WatchedViewModel = TrelloListViewModel.LoadViewModel(3, animeListDbContextFactory);
            StandByViewModel = TrelloListViewModel.LoadViewModel(4, animeListDbContextFactory);
            GiveUpViewModel = TrelloListViewModel.LoadViewModel(4, animeListDbContextFactory);
        }
    }
}
