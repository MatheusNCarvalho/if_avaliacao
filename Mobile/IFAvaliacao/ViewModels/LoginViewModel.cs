using System;
using System.Threading.Tasks;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Services.Response;
using IFAvaliacao.Utils.Extensions;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;
using Refit;
using Xamarin.Forms;

namespace IFAvaliacao.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        public LoginViewModel(INavigationService navigationService,
                             IUserService userService) : base(navigationService)
        {
            _userService = userService;
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

            try
            {
                await _userService.LoginAsync(Email, Password).ConfigureAwait(false);
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            catch (ValidationApiException validation)
            {
                var error = await validation.GetContentAsAsync<ErrorResponse>();
                await DialogService.AlertAsync(error.Message);
            }
            catch (ApiException apiException)
            {
                var error = await apiException.GetContentAsAsync<ErrorResponse>();
                await DialogService.AlertAsync(error.Message);

            }
            catch (Exception e)
            {
                await DialogService.AlertAsync(e.Message);
            }
        }

        private async Task ExecuteCadastrarCommand()
        {
            await NavigationService.NavigateAsync(nameof(CadastroUsuarioPage));
        }
    }
}
