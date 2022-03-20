using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloTagCreator
{
    public class DataBaseTrelloTagCreator : ITrelloTagCreator
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;

        public DataBaseTrelloTagCreator(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }

        public async Task CreateItem(TrelloItem trelloItem, Tag tag)
        {
            using (AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                TrelloItemDTO findTrello = context.TrelloItems.Find(trelloItem.mal_id);
                TagDTO findTag = context.Tags.Find(tag.id);

                context.TrelloItemTags.Add(ToTrelloItemTagDTO(findTrello, findTag));
                context.TrelloItems.Attach(findTrello);
                context.Tags.Attach(findTag);

                await context.SaveChangesAsync();
            }
        }

        private TrelloItemTagDTO ToTrelloItemTagDTO(TrelloItemDTO trelloItem, TagDTO tag)
        {
            return new TrelloItemTagDTO
            {
                trelloItemDto = trelloItem,
                tagDto = tag
            };
        }
    }
}
