using System.Threading.Tasks;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class FazendaViewModel : ViewModelBase
    {
        public FazendaViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
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
