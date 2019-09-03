using Acr.UserDialogs;
using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class PreenchimentoConcluidosViewModel : ViewModelBase
    {
        public PreenchimentoConcluidosViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Concluidos";
        }
    }
}
