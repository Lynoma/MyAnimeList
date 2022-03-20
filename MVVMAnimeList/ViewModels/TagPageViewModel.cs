using MVVMAnimeList.DbContexts;
using MVVMAnimeList.Models;
using MVVMAnimeList.Services.TrelloAllTagsProvider;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.ViewModels
{
    public class TagPageViewModel : ViewModelBase
    {
        public TagPageControlViewModel tagPageControlViewModel { get; }
        public TagPageViewModel(AnimeListDbContextFactory animeListDBContextFactory)
        {
            tagPageControlViewModel = TagPageControlViewModel.LoadPage(animeListDBContextFactory);
        }
    }
}
