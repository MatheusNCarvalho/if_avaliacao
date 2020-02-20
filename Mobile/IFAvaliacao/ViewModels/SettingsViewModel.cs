using Prism.Navigation;

namespace IFAvaliacao.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string EndApi
        {
            get { return AppSettings.ApiUrl; }
            set { AppSettings.ApiUrl = value; }
        }
    }
}
