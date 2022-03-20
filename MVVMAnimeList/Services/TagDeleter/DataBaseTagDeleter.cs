using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TagDeleter
{
    public class DataBaseTagDeleter : ITagDeleter
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public DataBaseTagDeleter(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }

        public async Task DeleteItem(Tag tag)
        {
            using (AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                TagDTO tagDTO = ToTagDTO(tag);
                context.Tags.Remove(tagDTO);
                await context.SaveChangesAsync();
            }
        }

        private TagDTO ToTagDTO(Tag tag)
        {
            return new TagDTO { color = tag.hexcode, name = tag.name, tag_id = tag.id };
        }
    }
}
