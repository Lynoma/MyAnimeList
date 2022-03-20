using MVVMAnimeList.DbContexts;
using MVVMAnimeList.DTOs;
using MVVMAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Services.TagCreator
{
    public class DataBaseTagCreator : ITagCreator
    {
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public DataBaseTagCreator(AnimeListDbContextFactory animeListDbContextFactory)
        {
            _animeListDbContextFactory = animeListDbContextFactory;
        }

        public async Task CreateItem()
        {
            using (AnimeListDbContext context = _animeListDbContextFactory.CreateDbContext())
            {
                TagDTO tagDTO = new TagDTO { color = "#ffffff", name = ""};
                context.Tags.Add(tagDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
