using System;
using MvvmCross.Core.ViewModels;
namespace MvvmNavDrawer.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        public SettingsViewModel()
        {
            Content = "Settings";
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
    }
}
