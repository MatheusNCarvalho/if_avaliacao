using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Title = "Home";
        }
    }
}