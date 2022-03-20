using MVVMAnimeList.Models;
using MVVMAnimeList.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.APISearch.ByID
{
    public class APISearchByID : ISearchByID
    {
        private readonly DetailsPageViewModel _detailsPageViewModel;
        public APISearchByID(DetailsPageViewModel detailsPageViewModel)
        {
            _detailsPageViewModel = detailsPageViewModel;
        }
        public async Task<AnimeByID> SearchByID()
        {
            var baseAddress = new Uri("https://api.jikan.moe/v3/");
            AnimeByID itemanim = new AnimeByID();
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                var response = await httpClient.GetAsync(String.Format("anime/{0}", _detailsPageViewModel._animeItem.mal_id));

                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<AnimeByID>(content);
                    itemanim = responseData;
                }
                return itemanim;
            }
        }
    }
}
