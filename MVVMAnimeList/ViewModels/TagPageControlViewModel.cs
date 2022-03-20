using MVVMAnimeList.Commands;
using MVVMAnimeList.Commands.Tags;
using MVVMAnimeList.DbContexts;
using MVVMAnimeList.Models;
using MVVMAnimeList.Services.TagCreator;
using MVVMAnimeList.Services.TagDeleter;
using MVVMAnimeList.Services.TagUpdater;
using MVVMAnimeList.Services.TrelloAllTagsProvider;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMAnimeList.ViewModels
{
    public class TagPageControlViewModel : ViewModelBase
    {
        private readonly ITrelloAllTagsProvider trelloAllTagsProvider;
        private readonly ITagCreator tagCreator;
        private readonly ITagUpdater tagUpdater;
        private readonly ITagDeleter tagDeleter;
        public ICommand LoadTrelloAllTagsCommand { get; }
        public ICommand AddTagCommand { get; }
        public ICommand UpdateTagCommand { get; }
        public ICommand DeleteTagCommand { get; }

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

        private Tag _selectedItem;

        public Tag SelectedItem
        {
            get { return _selectedItem; }
            set 
            { 
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public TagPageControlViewModel(AnimeListDbContextFactory animeListDBContextFactory)
        {
            trelloAllTagsProvider = new DataBaseTrelloAllTagsProvider(animeListDBContextFactory);
            tagCreator = new DataBaseTagCreator(animeListDBContextFactory);
            tagUpdater = new DataBaseTagUpdater(animeListDBContextFactory);
            tagDeleter = new DataBaseTagDeleter(animeListDBContextFactory);

            LoadTrelloAllTagsCommand = new LoadTagsCommand(this);
            AddTagCommand = new AddTagCommand(this);
            UpdateTagCommand = new UpdateTagCommand(this);
            DeleteTagCommand = new DeleteTagCommand(this);
            FullTagList = new ObservableCollection<Tag>();
        }

        public static TagPageControlViewModel LoadPage(AnimeListDbContextFactory animeListDBContextFactory)
        {
            TagPageControlViewModel vm = new TagPageControlViewModel(animeListDBContextFactory);
            vm.LoadTrelloAllTagsCommand.Execute(vm);
            return vm;
        }
        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await trelloAllTagsProvider.GetTags();
        }

        public async Task AddItem()
        {
            await tagCreator.CreateItem();
            FullTagList.Clear();
            this.LoadTrelloAllTagsCommand.Execute(this);
        }

        public async Task UpdateItem()
        {
            await tagUpdater.UpdateItem(SelectedItem);
        }

        public async Task DeleteItem()
        {
            await tagDeleter.DeleteItem(SelectedItem);
            FullTagList.Remove(SelectedItem);
        }
    }
}
