using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class VacaViewModel : ViewModelBase
    {
        public VacaViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }
    }
}
