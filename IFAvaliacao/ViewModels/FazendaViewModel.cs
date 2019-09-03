using System.Threading.Tasks;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;

namespace IFAvaliacao.ViewModels
{
    public class FazendaViewModel : ViewModelBase
    {
        public FazendaViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Fazendas";
            NavigatePageCommand = new DelegateCommand(async () => await NavigateToCadastroPage());
        }


        public DelegateCommand NavigatePageCommand { get; }

        private async Task NavigateToCadastroPage()
        {
            await NavigationService.NavigateAsync(nameof(CadastroFazendaPage));
        }
    }
}
