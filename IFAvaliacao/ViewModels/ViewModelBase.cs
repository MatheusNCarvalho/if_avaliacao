using Prism.Mvvm;
using Prism.Navigation;
using Acr.UserDialogs;

namespace IFAvaliacao.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; set; }
        protected IUserDialogs DialogService { get; set; }

        protected ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;       
        }


        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _subtitle;
        public string Subtitle
        {
            get => _subtitle;
            set => SetProperty(ref _subtitle, value);
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public virtual  void OnNavigatedFrom(INavigationParameters parameters)
        {

        }
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
        
        
        public virtual void Destroy()
        {

        }
    }
}