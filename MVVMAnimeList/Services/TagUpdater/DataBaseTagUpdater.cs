using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TagUpdater
{
    public class DataBaseTagUpdater : ITagUpdater
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public DataBaseTagUpdater(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }
        public async Task UpdateItem(Tag tag)
        {
            using (AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                TagDTO tagDTO = ToTagDTO(tag);
                context.Tags.Update(tagDTO);
                await context.SaveChangesAsync();
            }
        }

        private TagDTO ToTagDTO(Tag tag)
        {
            return new TagDTO { color = tag.hexcode, name = tag.name, tag_id = tag.id};
        }
    }
}
