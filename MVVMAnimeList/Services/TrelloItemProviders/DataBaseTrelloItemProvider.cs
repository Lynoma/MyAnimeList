using Microsoft.EntityFrameworkCore;
using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloItemProviders
{
    public class DataBaseTrelloItemProvider : ITrelloItemProvider
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public DataBaseTrelloItemProvider(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }
        public async Task<IEnumerable<TrelloItem>> GetAllTrelloItems(int idList)
        {
            using (AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                IEnumerable<TrelloItemDTO> trelloItemDTOs = await context.TrelloItems.Where(t => t.id_list == idList).ToListAsync();
                var test = trelloItemDTOs.Select(t => ToTrelloItem(t));
                return test;
            }
        }

        public static TrelloItem ToTrelloItem(TrelloItemDTO t)
        {
           return new TrelloItem { mal_id = t.mal_id, title = t.title, id_list = t.id_list };
        }
    }
}
