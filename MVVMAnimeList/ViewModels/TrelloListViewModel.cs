using MVVMAnimeList.Commands;
using MVVMAnimeList.Commands.TrelloTags;
using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using MVVMAnimeList.Services.TrelloAllTagsProvider;
using MVVMAnimeList.Services.TrelloItemCreators;
using MVVMAnimeList.Services.TrelloItemDeleters;
using MVVMAnimeList.Services.TrelloItemProviders;
using MVVMAnimeList.Services.TrelloItemUpdaters;
using MVVMAnimeList.Services.TrelloTagCreator;
using MVVMAnimeList.Services.TrelloTagProvider;
using MVVMAnimeList.Services.TrelloTagRemover;
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
    public class TrelloListViewModel : ViewModelBase
    {
        public readonly int _listId;
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        
        private readonly ITrelloItemProvider trelloItemProvider;
        private readonly ITrelloItemUpdater trelloItemUpdater;
        private readonly ITrelloItemDeleter trelloItemDeleter;
        private readonly ItrelloTagProvider trelloTagProvider;
        private readonly ITrelloAllTagsProvider trelloAllTagsProvider;
        private readonly ITrelloTagCreator trelloTagCreator;
        private readonly ITrelloTagRemover trelloTagRemover;
        public ICommand ItemReceivedCommand { get; }
        public ICommand ItemRemovedCommand { get; }
        public ICommand LoadTrelloItemsCommand { get; }
        public ICommand LoadTagsCommand { get; }
        public ICommand DeleteTrelloItemsCommand { get; }
        public ICommand AddTagItemCommand { get; }
        public ICommand RemoveTagItemCommand { get; }

        private TrelloItem _incomingItem;
        public TrelloItem IncomingItem 
        { 
            get
            {
                return _incomingItem;
            }
            set
            {
                _incomingItem = value;
                OnPropertyChanged(nameof(IncomingItem));
            }
        }

        private TrelloItem _removedItem;
        public TrelloItem RemovedItem
        {
            get
            {
                return _removedItem;
            }
            set
            {
                _removedItem = value;
                OnPropertyChanged(nameof(RemovedItem));
            }
        }

        private TrelloItem _rightClickedItem;

        public TrelloItem RightClickedItem
        {
            get 
            { 
                return _rightClickedItem; 
            }
            set 
            { 
                _rightClickedItem = value;
                OnPropertyChanged(nameof(RightClickedItem));
            }
        }

        private Tag _clickedTag;

        public Tag ClickedTag
        {
            get 
            { 
                return _clickedTag; 
            }
            set 
            { 
                _clickedTag = value;
                OnPropertyChanged(nameof(ClickedTag));
            }
        }



        private ObservableCollection<Tag> _fullTagList;

        public ObservableCollection<Tag> FullTagList
        {
            get { return _fullTagList; }
            set 
            { 
                _fullTagList = value;
                OnPropertyChanged(nameof(FullTagList));
            }
        }


        public ObservableCollection<TrelloItem> _listItem = new ObservableCollection<TrelloItem>();
        public ObservableCollection<TrelloItem> ListItem
        {
            get { return _listItem; }
            set 
            { 
                _listItem = value;
                OnPropertyChanged(nameof(ListItem));
            }
        }

        public TrelloListViewModel(int listId, AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
            ItemReceivedCommand = new ItemReceivedCommand(this);
            ItemRemovedCommand = new ItemRemovedCommand(this);
            LoadTrelloItemsCommand = new LoadTrelloItemsCommand(this);
            LoadTagsCommand = new LoadTagsCommand(this);
            DeleteTrelloItemsCommand = new DeleteTrelloItemsCommand(this);
            AddTagItemCommand = new AddTrelloTagCommand(this);
            RemoveTagItemCommand = new RemoveTrelloTagCommand(this);

            trelloItemProvider = new DataBaseTrelloItemProvider(animeListDbContextFactory);
            trelloItemUpdater = new DataBaseTrelloItemUpdater(animeListDbContextFactory);
            trelloItemDeleter = new DataBaseTrelloItemDeleter(animeListDbContextFactory);
            trelloTagProvider = new DataBaseTrelloTagProvider(animeListDbContextFactory);
            trelloTagCreator = new DataBaseTrelloTagCreator(animeListDbContextFactory);
            trelloTagRemover = new DataBaseTrelloTagRemover(animeListDbContextFactory);
            trelloAllTagsProvider = new DataBaseTrelloAllTagsProvider(animeListDbContextFactory);

            FullTagList = new ObservableCollection<Tag>();
            _listId = listId;
        }

        public static TrelloListViewModel LoadViewModel(int listId, AnimeListDbContextFactory animeListDbContextFactory)
        {
            TrelloListViewModel viewModel = new TrelloListViewModel(listId, animeListDbContextFactory);
            viewModel.LoadTrelloItemsCommand.Execute(viewModel);
            viewModel.LoadTagsCommand.Execute(viewModel);
            return viewModel;
        }

        public async Task<IEnumerable<TrelloItem>> GetAllItems()
        {
            return await trelloItemProvider.GetAllTrelloItems(_listId);
        }
        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await trelloAllTagsProvider.GetTags();
        }

        public async Task<ObservableCollection<Tag>> GetTags(TrelloItem item)
        {
            var tagDTO = await trelloTagProvider.GetTags(item);
            ObservableCollection<Tag> listTag = new ObservableCollection<Tag>();
            foreach(TagDTO tag in tagDTO)
            {
                listTag.Add(new Tag { hexcode = tag.color, name = tag.name });
            }
            return listTag;
        }

        public async Task UpdateList()
        {
            await trelloItemUpdater.UpdateTrelloItem(this, _listId);
        }

        public async Task DeleteItem(TrelloItem trelloItem)
        {
            await trelloItemDeleter.DeleteItem(trelloItem);
        }

        public async Task AddTagItem()
        {
            await trelloTagCreator.CreateItem(RightClickedItem, ClickedTag);
            ListItem.Clear();
            this.LoadTrelloItemsCommand.Execute(null);
        }

        public async Task RemoveTagItem()
        {
            await trelloTagRemover.RemoveItem(RightClickedItem, ClickedTag);
            ListItem.Clear();
            this.LoadTrelloItemsCommand.Execute(null);
        }
    }
}
