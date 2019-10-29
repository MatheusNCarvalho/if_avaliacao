﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using IFAvaliacao.Domain.Entities.Enum;
using IFAvaliacao.Views;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IFAvaliacao.ViewModels
{
    public class MainViewModel : ViewModelBase, IMasterDetailPageOptions
    {

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            MenuList = new ObservableCollection<Domain.Entities.Menu>();
            LoadMenu();

        }

        private DelegateCommand<Domain.Entities.Menu> _menuCommand;
        public DelegateCommand<Domain.Entities.Menu> MenuCommand => _menuCommand ?? (_menuCommand = new DelegateCommand<Domain.Entities.Menu>(async (itemSelect) => await ExecuteMenuComand(itemSelect)));

        private ObservableCollection<Domain.Entities.Menu> _menuList;
        public ObservableCollection<Domain.Entities.Menu> MenuList { get => _menuList; set => SetProperty(ref _menuList, value); }

        private Domain.Entities.Menu _itemSelected;
        public Domain.Entities.Menu ItemSelected { get => _itemSelected; set => SetProperty(ref _itemSelected, value); }
        public string Version
        {
            get { return $"{VersionTracking.CurrentBuild} ({VersionTracking.CurrentVersion})"; }
        }

        private void LoadMenu()
        {
            try
            {
                MenuList
                    .Add(new Domain.Entities.Menu("Avalições", 1, "checklist.png", EMenuType.Avaliacao, true, typeof(PreenchimentoTabPage)));
                MenuList
                    .Add(new Domain.Entities.Menu("Fazendas", 2, "house.png", EMenuType.Fazenda, true, typeof(FazendaPage)));
                MenuList
                    .Add(new Domain.Entities.Menu("Vacas", 3, "cow_face_front.png", EMenuType.Vaca, true, typeof(VacaPage)));
                MenuList
                    .Add(new Domain.Entities.Menu("Sair", 4, "logout", EMenuType.Exit, true, typeof(LoginPage)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        private async Task ExecuteMenuComand(Domain.Entities.Menu menu)
        {
            if (menu == null) return;

            if (menu.MenuType.Equals(EMenuType.Exit))
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
                return;
            }
            var mainPage = Application.Current.MainPage as NavigationPage;
            var masterDetail = mainPage.Navigation.NavigationStack.FirstOrDefault() as MasterDetailPage;
            masterDetail.IsPresented = false;

            masterDetail.Detail = new NavigationPage((Page)Activator.CreateInstance(menu.TargetType));
        }

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;

    }
}