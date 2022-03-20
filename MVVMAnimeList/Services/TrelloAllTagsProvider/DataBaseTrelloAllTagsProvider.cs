using Microsoft.EntityFrameworkCore;
using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TrelloAllTagsProvider
{
    public class DataBaseTrelloAllTagsProvider : ITrelloAllTagsProvider
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public DataBaseTrelloAllTagsProvider(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }
        public async Task<IEnumerable<Tag>> GetTags()
        {
            using (AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                IEnumerable<TagDTO> tagDTOs = await context.Tags.ToListAsync();
                var test = tagDTOs.Select(t => ToTag(t));
                return test;
            }
        }

        public static Tag ToTag(TagDTO t)
        {
            return new Tag { name = t.name, hexcode = t.color, id = t.tag_id};
        }
    }
}
