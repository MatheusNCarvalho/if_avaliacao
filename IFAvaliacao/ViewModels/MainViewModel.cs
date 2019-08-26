using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using IFAvaliacao.Models;
using IFAvaliacao.Models.Enum;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IFAvaliacao.ViewModels
{
    public class MainViewModel : ViewModelBase, IMasterDetailPageOptions
    {
        public DelegateCommand StartCommand { get; set; }
        public MainViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Title = "Home";
            MenuList = new ObservableCollection<Models.Menu>();
            StartCommand = new DelegateCommand(async () => await LoadNavigation());
        }


        private ObservableCollection<Models.Menu> _menuList;
        public ObservableCollection<Models.Menu> MenuList { get => _menuList; set => SetProperty(ref _menuList, value); }

        public string Verison
        {
            get { return $"{VersionTracking.CurrentBuild} ({VersionTracking.CurrentVersion})"; }
        }

        private void LoadMenu()
        {
            try
            {
                MenuList.Add(new Models.Menu("Avalicao", 1, "", EMenuType.Avaliacao, true, typeof(PreenchimentoTabPage)));
                MenuList.Add(new Models.Menu("Avalicao", 1, "", EMenuType.Avaliacao, true, typeof(PreenchimentoTabPage)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

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

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;

        private async Task LoadNavigation()
        {
            try
            {
                var parameters = new NavigationParameters { { nameof(ProfileCow), new ProfileCow(NameCow, BodyWight) } };
                NameCow = 0;
                BodyWight = 0;
                await NavigateToPage(nameof(PreenchimentoTabPage), parameters);
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