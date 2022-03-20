using MVVMAnimeList.Commands;
using MVVMAnimeList.DbContexts;
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
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand NavigateToSearch { get; }
        public ICommand NavigateToTrello { get; }
        public ICommand NavigateToTag { get; }
        public MainViewModel(NavigationStore navigationStore, AnimeListDbContextFactory animeListDbContextFactory)
        {
            NavigateToSearch = new NavigateSearchCommand(navigationStore, animeListDbContextFactory);
            NavigateToTrello = new NavigateTrelloCommand(navigationStore, animeListDbContextFactory);
            NavigateToTag = new NavigateTagCommand(navigationStore, animeListDbContextFactory);

            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
