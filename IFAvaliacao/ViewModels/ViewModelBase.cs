using System;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; set; }
        protected IPageDialogService PageDialogService { get; set; }

        protected ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;           
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