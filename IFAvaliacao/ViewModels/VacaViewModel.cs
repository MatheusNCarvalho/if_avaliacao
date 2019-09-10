using Acr.UserDialogs;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;

namespace IFAvaliacao.ViewModels
{
    public class VacaViewModel : ViewModelBase, IAsyncInitialization
    {
        public Task Initialization { get; }
        public VacaViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Vacas";
            NavigationToCadastroPageCommand = new DelegateCommand(async () => await ExecuteNavigationToCadastroPage());

        }

        public DelegateCommand NavigationToCadastroPageCommand { get; }



        private async Task ExecuteNavigationToCadastroPage()
        {
            await NavigationService.NavigateAsync(nameof(CadastroVacaPage));
        }
    }
}
