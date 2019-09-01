using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using IFAvaliacao.Models.Enum;
using IFAvaliacao.Views;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IFAvaliacao.ViewModels
{
    public class MainViewModel : ViewModelBase, IMasterDetailPageOptions
    {

        public MainViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            MenuList = new ObservableCollection<Models.Menu>();
            LoadMenu();

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
                MenuList
                    .Add(new Models.Menu("Avalições", 1, "checklist.png", EMenuType.Avaliacao, true, typeof(PreenchimentoTabPage)));
                MenuList
                    .Add(new Models.Menu("Fazendas", 1, "house.png", EMenuType.Avaliacao, true, typeof(PreenchimentoTabPage)));
                MenuList
                    .Add(new Models.Menu("Vacas", 1, "cow_face_front.png", EMenuType.Avaliacao, true, typeof(PreenchimentoTabPage)));
                MenuList
                    .Add(new Models.Menu("Sair", 1, "logout", EMenuType.Avaliacao, true, typeof(PreenchimentoTabPage)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }


        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;

    }
}