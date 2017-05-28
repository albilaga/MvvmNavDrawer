using MvvmCross.Core.ViewModels;
using MvvmNavDrawer.Core.Commons;

namespace MvvmNavDrawer.Core.Models
{
    public class MenuItem : MvxViewModel
    {
        private bool _isSelected;

        public string Title { get; set; }
        public MvxViewModel ViewModelType { get; set; }
        public MenuOption Option { get; set; }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                SetProperty(ref _isSelected, value);
            }
        }
    }
}
