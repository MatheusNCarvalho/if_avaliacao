using System.Threading.Tasks;
using IFAvaliacao.Utils.Extensions;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace IFAvaliacao.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            LoginCommand = new DelegateCommand(async () => await ExecuteLoginCommand());
            CadastrarCommand = new DelegateCommand(async () => await ExecuteCadastrarCommand());
        }

        private string _email;
        public string Email { get => _email; set => SetProperty(ref _email, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public DelegateCommand LoginCommand { get; }
        public DelegateCommand CadastrarCommand { get; }
        private async Task ExecuteLoginCommand()
        {
            if (!Email.HasValue())
            {
                await DialogService.AlertAsync("Email é obrigatorio", "Alerta", "Ok");
                return;
            }

            if (!Password.HasValue())
            {
                await DialogService.AlertAsync("Senha é obrigatorio", "Alerta", "Ok");
                return;
            }

            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        private async Task ExecuteCadastrarCommand()
        {
            await NavigationService.NavigateAsync(nameof(CadastroUsuarioPage));
        }
    }
}
