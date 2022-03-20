
using Microsoft.EntityFrameworkCore;
using MVVMAnimeList.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.DbContexts
{
    public class AnimeListDbContext : DbContext
    {
        public AnimeListDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TrelloItemDTO> TrelloItems { get; set; }
        public DbSet<TagDTO> Tags { get; set; }
        public DbSet<TrelloItemTagDTO> TrelloItemTags { get; set; }

    }
}
