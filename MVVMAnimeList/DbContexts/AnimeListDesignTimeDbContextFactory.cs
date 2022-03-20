using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.DbContexts
{
    public class AnimeListDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AnimeListDbContext>
    {
        public AnimeListDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=animelist.db").Options;
            return new AnimeListDbContext(options);
        }
    }
}
