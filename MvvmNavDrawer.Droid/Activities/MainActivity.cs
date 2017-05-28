
using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Shared.Caching;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmNavDrawer.Core.ViewModels;

namespace MvvmNavDrawer.Droid.Activities
{
    [Activity(Label = "Main Activity", Theme = "@style/MyTheme",
        LaunchMode = LaunchMode.SingleTop,
        ScreenOrientation = ScreenOrientation.Portrait,
        Name = "mytrains.droid.activities.MainActivity")]
    public class MainActivity : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        private DrawerLayout _drawerLayout;
        private MvxActionBarDrawerToggle _drawerToggle;
        private FragmentManager _fragmentManager;

        internal DrawerLayout DrawerLayout { get { return _drawerLayout; } }

        static MainActivity instance = new MainActivity();

        public static MainActivity CurrentActivity => instance;

        public new MainViewModel ViewModel
        {
            get { return base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _fragmentManager = FragmentManager;

            SetContentView(Resource.Layout.MainView);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _drawerToggle = new MvxActionBarDrawerToggle(this, _drawerLayout,
                                Resource.String.drawer_open, Resource.String.drawer_close);
            _drawerToggle.DrawerClosed += _drawerToggle_DrawerClosed;
            _drawerToggle.DrawerOpened += _drawerToggle_DrawerOpened;

            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _drawerToggle.DrawerIndicatorEnabled = true;
            _drawerLayout.AddDrawerListener(_drawerToggle);

            ViewModel.ShowMenu();
            ViewModel.ShowSearchJourneys();
        }

        private void _drawerToggle_DrawerOpened(object sender, ActionBarDrawerEventArgs e)
        {
            InvalidateOptionsMenu();
        }

        private void _drawerToggle_DrawerClosed(object sender, ActionBarDrawerEventArgs e)
        {
            InvalidateOptionsMenu();
        }

        //public override void OnBeforeFragmentChanging(IMvxCachedFragmentInfo fragmentInfo, Android.Support.V4.App.FragmentTransaction transaction)
        //{
        //    var currentFrag = SupportFragmentManager.FindFragmentById(Resource.Id.content_frame) as MvxFragment;

        //    if (currentFrag != null && fragmentInfo.ViewModelType != typeof(MenuViewModel)
        //        && currentFrag.FindAssociatedViewModelTypeOrNull() != fragmentInfo.ViewModelType)
        //        fragmentInfo.AddToBackStack = true;
        //    base.OnBeforeFragmentChanging(fragmentInfo, transaction);
        //}

        internal void CloseDrawerMenu()
        {
            _drawerLayout.CloseDrawers();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (_drawerToggle.OnOptionsItemSelected(item))
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            _drawerToggle.SyncState();
        }
    }
}