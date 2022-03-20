using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloItemCreators
{
    public class DataBaseTrelloItemCreator : ITrelloItemCreator
    {
        private bool IsRunning = false;
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public DataBaseTrelloItemCreator(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }
        public async Task CreateItem(TrelloItem trelloItem)
        {
            if (!IsRunning)
            {
                IsRunning = true;
                using (AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
                {

                    TrelloItemDTO trelloItemDTO = ToTrelloItemDTO(trelloItem);

                    if (!context.TrelloItems.Contains<TrelloItemDTO>(trelloItemDTO))
                    {
                        context.TrelloItems.Add(trelloItemDTO);
                        await context.SaveChangesAsync();
                    }
                }
                IsRunning = false;
            }
        }

        private TrelloItemDTO ToTrelloItemDTO(TrelloItem trelloItem)
        {
            return new TrelloItemDTO
            {
                mal_id = trelloItem.mal_id,
                title = trelloItem.title,
                id_list = trelloItem.id_list,
            };
        }
    }
}
