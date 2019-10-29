using Acr.UserDialogs;
using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class PreenchimentoTabViewModel : ViewModelBase
    {
        public PreenchimentoTabViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Avaliações";
        }
    }
}
