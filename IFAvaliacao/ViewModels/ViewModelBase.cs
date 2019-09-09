using Prism.Mvvm;
using Prism.Navigation;
using Acr.UserDialogs;
using System;

namespace IFAvaliacao.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; set; }
        protected IUserDialogs DialogService { get; set; }

        protected ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            DialogService = UserDialogs.Instance;
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

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void ToastSuccess(string message)
        {
            var toastConfig = new ToastConfig(message);
            toastConfig.SetBackgroundColor(System.Drawing.Color.Green);
            DialogService.Toast(toastConfig);
        }

        public void ToastError(string message)
        {
            var toastConfig = new ToastConfig(message);
            toastConfig.SetBackgroundColor(System.Drawing.Color.Red);
            toastConfig.SetDuration(7000);
            DialogService.Toast(toastConfig);
        }

        public void ToastWarning(string message)
        {
            var toastConfig = new ToastConfig(message);
            toastConfig.SetBackgroundColor(System.Drawing.Color.Gold);
            toastConfig.SetMessageTextColor(System.Drawing.Color.Black);
            toastConfig.SetDuration(7000);
            DialogService.Toast(toastConfig);
        }



        public virtual void Destroy()
        {

        }
    }
}