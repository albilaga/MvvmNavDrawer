using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmNavDrawer.Core.Commons;
using MvvmNavDrawer.Core.Models;

namespace MvvmNavDrawer.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        public MvxCommand<MenuItem> MenuItemSelectCommand => new MvxCommand<MenuItem>(OnMenuEntrySelect);
        public MvxObservableCollection<MenuItem> MenuItems { get; }

        public event EventHandler CloseMenu;

        private IMvxNavigationService _navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItems = new MvxObservableCollection<MenuItem>();
            CreateMenuItems();
        }

        private void CreateMenuItems()
        {
            MenuItems.Add(new MenuItem
            {
                Title = "Search Journey",
                ViewModelType = Mvx.IocConstruct<SearchJourneyViewModel>(),
                Option = MenuOption.SearchJourney,
                IsSelected = true
            });

            MenuItems.Add(new MenuItem
            {
                Title = "My Saved Journeys",
                ViewModelType = Mvx.IocConstruct<SavedJourneysViewModel>(),
                Option = MenuOption.SavedJourneys,
                IsSelected = false
            });

            MenuItems.Add(new MenuItem
            {
                Title = "Settings",
                ViewModelType = Mvx.IocConstruct<SettingsViewModel>(),
                Option = MenuOption.Settings,
                IsSelected = false
            });
        }

        private void OnMenuEntrySelect(MenuItem item)
        {
            _navigationService.Navigate(item.ViewModelType);
            RaiseCloseMenu();
        }

        private void RaiseCloseMenu()
        {
            CloseMenu?.Invoke(this, EventArgs.Empty);
        }
    }
}