using MvvmNavDrawer.Core.ViewModels;

namespace MvvmNavDrawer.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<LoginViewModel>();
        }
    }
}
