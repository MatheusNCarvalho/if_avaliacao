using System.Threading.Tasks;
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
        }

        private string _email;
        public string Email { get => _email; set => SetProperty(ref _email, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public DelegateCommand LoginCommand { get; }
        private async Task ExecuteLoginCommand()
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
            //await NavigationService.NavigateAsync(nameof(MainPage));
        }
    }
}
