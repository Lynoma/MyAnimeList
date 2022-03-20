using MVVMAnimeList.Models;
using MVVMAnimeList.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.APISearch.ByName
{
    public class APISearchByName : ISearchByName
    {
        public async Task searchByName(SearchPageViewModel searchPageViewModel)
        {
            var baseAddress = new Uri("https://api.jikan.moe/v3/");
            ObservableCollection<AnimeItem> theAnimeList = new ObservableCollection<AnimeItem>();

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                var response = await httpClient.GetAsync(String.Format("search/anime?q={0}&page=1", searchPageViewModel.SearchInput));

                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<SearchAnime>(content);
                    foreach (var item in responseData.results)
                    {
                        AnimeItem theAnimeItem = new AnimeItem();
                        theAnimeItem.mal_id = item.mal_id;
                        theAnimeItem.rated = item.rated;
                        theAnimeItem.score = item.score;
                        theAnimeItem.image_url = item.image_url;
                        theAnimeItem.type = item.type;
                        theAnimeItem.members = item.members;
                        theAnimeItem.start_date = item.start_date;
                        theAnimeItem.end_date = item.end_date;
                        theAnimeItem.airing = item.airing;
                        theAnimeItem.episodes = item.episodes;
                        theAnimeItem.title = item.title;
                        theAnimeItem.synopsys = item.synopsys;
                        theAnimeItem.url = item.url;
                        theAnimeList.Add(theAnimeItem);
                    }
                }
                searchPageViewModel.listSearchItems = theAnimeList;

            }
            
        }
    }
}
