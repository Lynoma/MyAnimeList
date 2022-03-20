using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloItemDeleters
{
    public class DataBaseTrelloItemDeleter : ITrelloItemDeleter
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public DataBaseTrelloItemDeleter(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }
        public async Task DeleteItem(TrelloItem trelloItem)
        {
            using(AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                context.TrelloItems.Remove(ToTrelloItemDTO(trelloItem));
                await context.SaveChangesAsync();
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
