using Microsoft.EntityFrameworkCore;
using MVVMAnimeList.DbContexts;
using MVVMAnimeList.Store;
using MVVMAnimeList.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMAnimeList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private const string CONNECTION_STRING = "Data Source=animelist.db";

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            AnimeListDbContextFactory animeListDbContextFactory = new AnimeListDbContextFactory(CONNECTION_STRING);
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (AnimeListDbContext dbContext = new AnimeListDbContext(options))
            {
                dbContext.Database.Migrate();
            }


            _navigationStore.CurrentViewModel = new TrelloPageViewModel(animeListDbContextFactory);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, animeListDbContextFactory)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
