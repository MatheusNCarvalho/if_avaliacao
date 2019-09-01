using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class PreenchimentoTabViewModel : ViewModelBase
    {
        public PreenchimentoTabViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Title = "Avaliações";
        }
    }
}
