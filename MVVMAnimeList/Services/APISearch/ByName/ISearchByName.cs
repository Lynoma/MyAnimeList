using MVVMAnimeList.Models;
using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.APISearch.ByName
{
    public interface ISearchByName
    {
        Task searchByName(SearchPageViewModel searchPageViewModel);
    }
}
