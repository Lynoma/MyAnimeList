using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloItemUpdaters
{
    public class DataBaseTrelloItemUpdater : ITrelloItemUpdater
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public DataBaseTrelloItemUpdater(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }
        public async Task UpdateTrelloItem(TrelloListViewModel trelloListViewModel, int idList)
        {
            TrelloItemDTO item = ToDTO(trelloListViewModel.IncomingItem);
            using (AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                var selectItem = await context.TrelloItems.FindAsync(item.mal_id);
                selectItem.id_list = idList;
                context.SaveChanges();
            }
        }

        private TrelloItemDTO ToDTO(TrelloItem trelloItem)
        {
            TrelloItemDTO dto = new TrelloItemDTO
            {
                mal_id = trelloItem.mal_id,
                id_list = trelloItem.id_list,
                title = trelloItem.title,
            };
            return dto;
        }
    }
}
