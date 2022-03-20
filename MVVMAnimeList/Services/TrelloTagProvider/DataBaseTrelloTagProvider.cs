using Microsoft.EntityFrameworkCore;
using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloTagProvider
{
    public class DataBaseTrelloTagProvider : ItrelloTagProvider
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public DataBaseTrelloTagProvider(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }
        public async Task<IEnumerable<TagDTO>> GetTags(TrelloItem item)
        {
            using (AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                IEnumerable<TrelloItemTagDTO> trelloItemTagDTOs = await context.TrelloItemTags.Include(x => x.tagDto).Where(t => t.trelloItemDto.mal_id == item.mal_id).ToListAsync();
                var test = trelloItemTagDTOs.Select(t => t.tagDto);
                return test;
            }
        }
    }
}
