﻿using MVVMAnimeList.DbContexts;
using MVVMAnimeList.Store;
using MVVMAnimeList.ViewModels;
using MVVMEssentials.Commands;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAnimeList.Commands
{
    public class NavigateSearchCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly AnimeListDbContextFactory _animeListDbContextFactory;
        public NavigateSearchCommand(NavigationStore navigationStore, AnimeListDbContextFactory animeListDbContextFactory)
        {
            _navigationStore = navigationStore;
            _animeListDbContextFactory = animeListDbContextFactory;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new SearchPageViewModel(_navigationStore, _animeListDbContextFactory);
        }
    }
}
