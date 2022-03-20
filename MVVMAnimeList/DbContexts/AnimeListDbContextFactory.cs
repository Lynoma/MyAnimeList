using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.DbContexts
{
    public class AnimeListDbContextFactory
    {
        private readonly string _connectionString;
        public AnimeListDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public AnimeListDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new AnimeListDbContext(options);
        }
    }
}
