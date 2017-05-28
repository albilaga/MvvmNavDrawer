
using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmNavDrawer.Core.ViewModels;

namespace MvvmNavDrawer.Droid.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : MvxCachingFragmentCompatActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginView);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            // Create your application here
        }
    }
}
