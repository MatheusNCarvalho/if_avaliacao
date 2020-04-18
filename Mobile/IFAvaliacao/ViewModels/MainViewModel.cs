using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using IFAvaliacao.Domain.Entities.Enum;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Services.Response;
using IFAvaliacao.Utils;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IFAvaliacao.ViewModels
{
    public class MainViewModel : ViewModelBase, IMasterDetailPageOptions
    {
        private readonly ISyncService _syncService;

        public MainViewModel(INavigationService navigationService, ISyncService syncService) : base(navigationService)
        {
            MenuList = new ObservableCollection<Domain.Entities.Menu>();
            _syncService = syncService;
            LoadMenu();
        }

        private DelegateCommand<Domain.Entities.Menu> _menuCommand;
        public DelegateCommand<Domain.Entities.Menu> MenuCommand => _menuCommand ?? (_menuCommand = new DelegateCommand<Domain.Entities.Menu>(async (itemSelect) => await ExecuteMenuComand(itemSelect)));

        private ObservableCollection<Domain.Entities.Menu> _menuList;
        public ObservableCollection<Domain.Entities.Menu> MenuList { get => _menuList; set => SetProperty(ref _menuList, value); }

        private Domain.Entities.Menu _itemSelected;
        public Domain.Entities.Menu ItemSelected { get => _itemSelected; set => SetProperty(ref _itemSelected, value); }
        public string Version => $"{VersionTracking.CurrentVersion} ({VersionTracking.CurrentBuild})";

        private string _usuarioNome = AppSettings.Usuario?.Name;
        public string UsuarioNome { get => _usuarioNome; set => SetProperty(ref _usuarioNome, value); }

        private string _email = AppSettings.Usuario?.Email;
        public string Email { get => _email; set => SetProperty(ref _email, value); }

        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;

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
                 .Add(new Domain.Entities.Menu("Sincronizar", 4, "synchronization.png", EMenuType.Sincronizar, true, typeof(LoginPage)));
                MenuList
                    .Add(new Domain.Entities.Menu("Sair", 4, "logout", EMenuType.Exit, true, typeof(LoginPage)));
                MenuList
                    .Add(new Domain.Entities.Menu("Configurações", 4, "settings.png", EMenuType.Configuration, true, typeof(SettingsPage)));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        private async Task ExecuteMenuComand(Domain.Entities.Menu menu)
        {
            if (menu == null || ItemSelected == null) return;

            var mainPage = Application.Current.MainPage as NavigationPage;
            var masterDetail = mainPage.Navigation.NavigationStack.FirstOrDefault() as MasterDetailPage;

            try
            {
                masterDetail.IsPresented = false;
            }
            catch (Exception)
            {

            }

            if (menu.MenuType.Equals(EMenuType.Exit))
            {
                var connfirmConfig = new ConfirmConfig()
                               .SetTitle("Alerta")
                               .SetMessage("Deseja realmente sair do aplicativo?")
                               .SetOkText("Sim")
                               .SetCancelText("Não");

                var confirm = await DialogService.ConfirmAsync(connfirmConfig);
                if (!confirm)
                {
                    return;
                }
                AppSettings.RemoverUsuarioLogado();
                Helpers.SetNavigationPageRoot(typeof(LoginPage));
                return;
            }

            if (menu.MenuType == EMenuType.Sincronizar)
            {
                await Sync();
                return;
            }


            masterDetail.Detail = new NavigationPage((Page)Activator.CreateInstance(menu.TargetType));
        }


        private async Task Sync()
        {
            if (!Helpers.IsConnected)
            {
                ItemSelected = null;
                await DialogService.AlertAsync("Parece que você não está conecatado. Verifique sua conexão com a internet", "Oops...", "OK");
                return;
            }
            var connfirmConfig = new ConfirmConfig()
                        .SetTitle("Alerta")
                        .SetMessage("Deseja sincronizar os dados ?")
                        .SetOkText("Sim")
                        .SetCancelText("Não");

            var confirm = await DialogService.ConfirmAsync(connfirmConfig);
            if (!confirm)
            {
                return;
            }

            try
            {
                DialogService.ShowLoading("Aguarde, sincronizando...");
                await _syncService.PullAsync();
                await _syncService.PushAsync();
            }
            catch (ValidationApiException validation)
            {
                DialogService.HideLoading();
                var error = await validation.GetContentAsAsync<ErrorResponse>();
                await DialogService.AlertAsync(error.Message);
            }
            catch (ApiException apiException)
            {
                DialogService.HideLoading();
                var error = await apiException.GetContentAsAsync<ErrorResponse>();
                await DialogService.AlertAsync(apiException.StatusCode == System.Net.HttpStatusCode.NotFound ? "Api não encontrada" : error?.Message);

            }
            catch (Exception e)
            {
                DialogService.HideLoading();
                await DialogService.AlertAsync(e.Message);
            }
            finally
            {
                DialogService.HideLoading();
            }
        }



    }
}