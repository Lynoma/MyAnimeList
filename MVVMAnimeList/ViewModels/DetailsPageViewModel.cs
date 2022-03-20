using MVVMAnimeList.Commands;
using MVVMAnimeList.DbContexts;
using MVVMAnimeList.Models;
using MVVMAnimeList.Services.APISearch.ByID;
using MVVMAnimeList.Services.TrelloItemCreators;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMAnimeList.ViewModels
{
    public class DetailsPageViewModel : ViewModelBase
    {
        public readonly AnimeItem _animeItem;
        private readonly ITrelloItemCreator trelloItemCreator;
        private readonly ISearchByID searchByID;
        private AnimeByID _animeByID;
        public AnimeByID animeByID
        {
            get { return _animeByID; }
            set 
            { 
                _animeByID = value;
                OnPropertyChanged(nameof(animeByID));
            }
        }
        
        private bool _canExec;
        public bool canExec 
        {
            get { return _canExec; }
            set
            {
                _canExec = value;
                OnPropertyChanged(nameof(canExec));
            }
        }
        public ICommand CreateItem { get; set; }
        public DetailsPageViewModel(AnimeItem animeItem, AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeItem = animeItem;
            CreateItem = new AddTrelloItemCommand(this);
            trelloItemCreator = new DataBaseTrelloItemCreator(animeListDbContextFactory);
            searchByID = new APISearchByID(this);
            canExec = true;
        }

        public async static Task<DetailsPageViewModel> LoadPage(AnimeItem animeItem, AnimeListDbContextFactory animeListDbContextFactory)
        {
            DetailsPageViewModel vm = new DetailsPageViewModel(animeItem, animeListDbContextFactory);
            vm.animeByID = await vm.searchByID.SearchByID();
            return vm;
        }

        public async Task AddItem()
        {
            if (canExec)
            {
                trelloItemCreator.CreateItem(ConvertToTrello(_animeItem));
                canExec = false;
            }
        }

        private TrelloItem ConvertToTrello(AnimeItem animeItem)
        {
            return new TrelloItem
            {
                id_list = 1,
                mal_id = animeItem.mal_id,
                title = animeItem.title,
            };
        }
    }
}
