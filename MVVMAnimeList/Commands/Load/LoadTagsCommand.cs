using MVVMAnimeList.Models;
using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands
{
    public class LoadTagsCommand : AsyncCommandBase
    {
        private readonly TrelloListViewModel _trelloListViewModel;
        private readonly TagPageControlViewModel _tagPageControlViewModel;
        public LoadTagsCommand(TrelloListViewModel trelloListViewModel)
        {
            _trelloListViewModel = trelloListViewModel;
        }

        public LoadTagsCommand(TagPageControlViewModel tagPageControlViewModel)
        {
            _tagPageControlViewModel = tagPageControlViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if(_trelloListViewModel != null)
            {
                IEnumerable<Tag> trelloItems = await _trelloListViewModel.GetAllTags();
                foreach (Tag tag in trelloItems)
                {
                    _trelloListViewModel.FullTagList.Add(tag);
                }
            }
            else
            {
                IEnumerable<Tag> trelloItems = await _tagPageControlViewModel.GetAllTags();
                foreach (Tag tag in trelloItems)
                {
                    _tagPageControlViewModel.FullTagList.Add(tag);
                }
            }
            
        }
    }
}
