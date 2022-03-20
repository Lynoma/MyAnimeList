using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloTagRemover
{
    public class DataBaseTrelloTagRemover : ITrelloTagRemover
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;

        public DataBaseTrelloTagRemover(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }

        public async Task RemoveItem(TrelloItem trelloItem, Tag tag)
        {
            using(AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                TrelloItemTagDTO findItem = context.TrelloItemTags.FirstOrDefault(item => item.tagDto.tag_id == tag.id && item.trelloItemDto.mal_id == trelloItem.mal_id);
                TrelloItemTagDTO getItem = context.TrelloItemTags.Find(findItem.trelloItem_tag_id);

                context.TrelloItemTags.Remove(getItem);

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

        private TagDTO ToTagDTO(Tag tag)
        {
            return new TagDTO { color = tag.hexcode, name = tag.name, tag_id = tag.id };
        }
    }
}
