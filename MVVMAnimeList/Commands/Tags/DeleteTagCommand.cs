using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands.Tags
{
    public class DeleteTagCommand : AsyncCommandBase
    {
        private readonly TagPageControlViewModel _tagControlViewModel;
        public DeleteTagCommand(TagPageControlViewModel tagPageControlViewModel)
        {
            _tagControlViewModel = tagPageControlViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _tagControlViewModel.DeleteItem();
        }
    }
}
