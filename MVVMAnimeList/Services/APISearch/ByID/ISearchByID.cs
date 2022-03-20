using MVVMAnimeList.Models;
using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.APISearch.ByID
{
    public interface ISearchByID
    {
        Task<AnimeByID> SearchByID();
    }
}
