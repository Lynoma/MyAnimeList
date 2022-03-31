using MVVMAnimeList.Commands;
using MVVMAnimeList.DbContexts;
using MVVMAnimeList.Models;
using MVVMAnimeList.Services.APISearch.ByName;
using MVVMAnimeList.Store;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMAnimeList.ViewModels
{
    public class SearchPageViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ISearchByName searchByName;
        private string _searchInput;
        public string SearchInput
        {
            get { return _searchInput; }
            set 
            {
                _searchInput = value;
                OnPropertyChanged(nameof(_searchInput));
            }
        }
        private ObservableCollection<AnimeItem> _listSearchItems;

        public ObservableCollection<AnimeItem> listSearchItems
        {
            get { return _listSearchItems; }
            set 
            { 
                _listSearchItems = value;
                OnPropertyChanged(nameof(listSearchItems));
            }
        }
        private AnimeItem _selectionChanged;

        public AnimeItem SelectionChanged 
        { 
            get { return _selectionChanged; }
            set 
            { 
                _selectionChanged = value;
                OnPropertyChanged(nameof(SelectionChanged));
            }
        }


        public ICommand searchCommand { get; }
        public ICommand navigateDetails { get; }

        public SearchPageViewModel(NavigationStore navigationStore, AnimeListDbContextFactory animeListDbContextFactory)
        {
            searchCommand = new SearchCommand(this);
            searchByName = new APISearchByName();
            _navigationStore = navigationStore;
            navigateDetails = new NavigateDetailsCommand(_navigationStore, this, animeListDbContextFactory);
        }

        public async Task SearchAPI()
        {
            searchByName.searchByName(this);
        }
    }
}
