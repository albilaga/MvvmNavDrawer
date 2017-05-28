using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
namespace MvvmNavDrawer.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;
        public LoginViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private MvxCommand _loginCommand;
        public IMvxCommand LoginCommand
        {
            get
            {
                return _loginCommand = _loginCommand ?? new MvxCommand(() =>
                    {
                        _navigationService.Navigate<MainViewModel>();
                    });
            }
        }
    }
}
