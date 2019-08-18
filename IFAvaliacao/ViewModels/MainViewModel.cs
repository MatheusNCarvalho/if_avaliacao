using System;
using System.Threading.Tasks;
using IFAvaliacao.Models;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace IFAvaliacao.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public DelegateCommand StartCommand { get; set; }
        public MainViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Title = "Home";
            StartCommand = new DelegateCommand(async () => await LoadNavigation());
        }

        private int _nameCow;

        public int NameCow
        {
            get => _nameCow;
            set => SetProperty(ref _nameCow, value);
        }

        private decimal _bodyWight;
        public decimal BodyWight
        {
            get => _bodyWight;
            set => SetProperty(ref _bodyWight, value);
        }


        private async Task LoadNavigation()
        {
            try
            {
                var parameters = new NavigationParameters { { nameof(ProfileCow), new ProfileCow(NameCow, BodyWight) } };
                NameCow = 0;
                BodyWight = 0;
                await NavigateToPage(nameof(PreenchimentoPage), parameters);
            }
            catch (Exception e)
            {
                await PageDialogService.DisplayAlertAsync("Opss..", e.Message, "OK");
            }
        }

        public async Task NavigateToPage(string page, NavigationParameters parameters)
        {
            await NavigationService.NavigateAsync(page, parameters);
        }

    }
}