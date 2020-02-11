using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Api;
using IFAvaliacao.Services.Response;
using IFAvaliacao.Utils.Extensions;
using Prism.Commands;
using Prism.Navigation;
using Refit;

namespace IFAvaliacao.ViewModels
{
    public class CadastroUsuarioVieModel : ViewModelBase
    {
        public CadastroUsuarioVieModel(INavigationService navigationService) : base(navigationService)
        {
            CadastrarCommand = new DelegateCommand(async () => await ExecuteLoginCommand());
        }

        private string _name;
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        private string _email;
        public string Email { get => _email; set => SetProperty(ref _email, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        private string _confirmarPassword;
        public string ConfirmarPassword { get => _confirmarPassword; set => SetProperty(ref _confirmarPassword, value); }

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

            if (Password != ConfirmarPassword)
            {
                await DialogService.AlertAsync("Senha deve ser igual há confirmar senha", "Alerta", "Ok");
                return;
            }


            try
            {
                var usuarioService = RestService.For<ICadastrarUsuarioApi>(AppSettings.ApiUrl);
                var response = await usuarioService.Post(new Usuario { Email = Email, Password = Password, Name = Name, PasswordConfirmation = ConfirmarPassword });

                Console.WriteLine(response);
            }
            catch (ValidationApiException validation)
            {
               var error = await validation.GetContentAsAsync<ErrorResponse>();
               await DialogService.AlertAsync(error.Message);

                Console.WriteLine(validation);
            }
            catch (ApiException apiException)
            {
                var error = await apiException.GetContentAsAsync<ErrorResponse>();
                await DialogService.AlertAsync(error.Message);
                Console.WriteLine(apiException);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }


    }
}
