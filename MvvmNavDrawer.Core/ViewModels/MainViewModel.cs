using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MvvmNavDrawer.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly Lazy<SearchJourneyViewModel> _searchJourneyViewModel;
        private readonly Lazy<SavedJourneysViewModel> _savedJourneysViewModel;
        private readonly Lazy<SettingsViewModel> _settingsViewModel;

        public SearchJourneyViewModel SearchJourneyViewModel => _searchJourneyViewModel.Value;

        public SavedJourneysViewModel SavedJourneysViewModel => _savedJourneysViewModel.Value;

        public SettingsViewModel SettingsViewModel => _settingsViewModel.Value;

        public MenuViewModel MenuViewModel;

        private IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _searchJourneyViewModel = new Lazy<SearchJourneyViewModel>(Mvx.IocConstruct<SearchJourneyViewModel>);
            _savedJourneysViewModel = new Lazy<SavedJourneysViewModel>(Mvx.IocConstruct<SavedJourneysViewModel>);
            _settingsViewModel = new Lazy<SettingsViewModel>(Mvx.IocConstruct<SettingsViewModel>);
        }

        public void ShowMenu()
        {
            _navigationService.Navigate<MenuViewModel>();
        }

        public void ShowSearchJourneys()
        {
            _navigationService.Navigate<SearchJourneyViewModel>();
        }
    }
}