using MvvmCross.Core.ViewModels;
namespace MvvmNavDrawer.Core.ViewModels
{
    public class SearchJourneyViewModel : MvxViewModel
    {
        public SearchJourneyViewModel()
        {
            Content = "Search Journey";
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
    }
}
