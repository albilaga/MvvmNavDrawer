using MvvmCross.Core.ViewModels;
namespace MvvmNavDrawer.Core.ViewModels
{
    public class SavedJourneysViewModel : MvxViewModel
    {
        public SavedJourneysViewModel()
        {
            Content = "Saved Journeys";
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
    }
}
