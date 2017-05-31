using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using MvvmNavDrawer.Core.ViewModels;
using MvvmNavDrawer.Droid.Activities;

namespace MvvmNavDrawer.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.left_drawer)]
    [Register("mvvmnavdrawer.droid.views.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>
    {
        public MenuFragment()
        {

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_menu, null);
        }

        public override void OnStart()
        {
            base.OnStart();
            ViewModel.CloseMenu += OnCloseMenu;
        }

        public override void OnStop()
        {
            base.OnStop();
            ViewModel.CloseMenu -= OnCloseMenu;
        }

        private void OnCloseMenu(object sender, EventArgs e)
        {
            (Activity as MainActivity)?.CloseDrawerMenu();
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            return true;
        }
    }
}