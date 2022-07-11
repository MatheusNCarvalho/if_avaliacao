using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IFAvaliacao.Extensions;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Services.Response;
using IFAvaliacao.Utils;
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
        private readonly ISyncService _syncService;

        public LoginViewModel(INavigationService navigationService,
                             IUserService userService,
                             ISyncService syncService) : base(navigationService)
        {
            _userService = userService;
            _syncService = syncService;
            LoginCommand = new DelegateCommand(async () => await ExecuteLoginCommand());
            CadastrarCommand = new DelegateCommand(async () => await ExecuteCadastrarCommand());
            AlterarEndpointCommand = new DelegateCommand(async () => await AlterarEndpointUrlAsync());
        }

        public string EndpointApi
        {
            get { return AppSettings.ApiUrl; }
            set { AppSettings.ApiUrl = value; }
        }

        private string _email;
        public string Email { get => _email; set => SetProperty(ref _email, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public DelegateCommand AlterarEndpointCommand { get; private set; }
        public async Task AlterarEndpointUrlAsync()
        {
            var input = await DialogService.PromptAsync($"{EndpointApi}", "Alterar url do webservice", "Confirmar", "Cancelar");

            if (InputValido(input))
            {
                if(IsValidURL(input.Text))
                {
                    EndpointApi = input.Text;
                    return;
                }

                await DialogService.AlertAsync("Url informada é inválida");
            }
        }


        private bool InputValido(Acr.UserDialogs.PromptResult input)
        {

            return input.Ok && !string.IsNullOrEmpty(input.Text) && input.Text.Length > 0;
        }

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
                DialogService.ShowLoading("Realizando autenticação, aguarde...");
                await _userService.LoginAsync(Email, Password);
                if (AppSettings.PrimeiraInicializacao)
                {
                    DialogService.HideLoading();
                    DialogService.ShowLoading("Preparando o aplicativo para o primeiro uso, aguarde...");
                    await _syncService.PullAsync();
                    AppSettings.PrimeiraInicializacao = false;
                }
                Helpers.SetNavigationPageRoot(typeof(MainPage));
            }
            catch (ValidationApiException validation)
            {
                DialogService.HideLoading();
                var error = await validation.GetContentAsAsync<ErrorResponse>();
                await DialogService.AlertAsync(error?.Message);
            }
            catch (ApiException apiException)
            {
                DialogService.HideLoading();
                var error = await apiException.GetContentAsAsync<ErrorResponse>();
                await DialogService.AlertAsync(error?.Message);

            }
            catch (Exception e)
            {
                DialogService.HideLoading();
                await DialogService.AlertAsync(e.Message);
            }
            finally
            {
                DialogService.HideLoading();
            }
        }

        private async Task ExecuteCadastrarCommand()
        {
            await NavigationService.NavigateAsync(nameof(CadastroUsuarioPage));
        }

        private bool IsValidURL(string url)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            var regex = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(url);
        }
    }
}
