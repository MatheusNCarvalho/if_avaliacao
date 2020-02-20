using Acr.UserDialogs;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IFAvaliacao.ViewModels
{
    public class VacaViewModel : ViewModelBase, IAsyncInitialization
    {
        public Task Initialization { get; }
        private readonly IVacaService _vacaService;
        public VacaViewModel(INavigationService navigationService,
                             IVacaService vacaService) : base(navigationService)
        {
            Title = "Vacas";
            NavigationToCadastroPageCommand = new DelegateCommand(async () => await ExecuteNavigationToCadastroPage());
            VacaActionsCommand = new DelegateCommand(async () => await ExecuteActionsCommand());
            _vacaService = vacaService;

        }

        public DelegateCommand NavigationToCadastroPageCommand { get; }
        public DelegateCommand VacaActionsCommand { get; }

        private ObservableCollection<Vaca> _vacas;
        public ObservableCollection<Vaca> Vacas { get => _vacas; set => SetProperty(ref _vacas, value); }

        public Vaca Vaca { get; set; }

        private Vaca _vacaSelecionada;
        public Vaca VacaSelecionada { get => _vacaSelecionada; set => SetProperty(ref _vacaSelecionada, value); }


        public async Task LoadAsync()
        {
            var vacas = await _vacaService.GetAllAsync();
            Vacas = new ObservableCollection<Vaca>(vacas);
        }

        private async Task ExecuteNavigationToCadastroPage()
        {
            await NavigationService.NavigateAsync(nameof(CadastroVacaPage));
        }

        private async Task ExecuteActionsCommand()
        {
            if (VacaSelecionada == null) return;

            var actionConfig = new ActionSheetConfig()
                .SetTitle("Escolha uma opção para continuar.")
                .SetCancel("Cancelar.")
                .Add("Editar cadastro", async () => await EditarVaca())
                .Add("Excluir cadastro", async () => await ExcluirVaca())
                .SetUseBottomSheet(true);

            DialogService.ActionSheet(actionConfig);
            Vaca = VacaSelecionada;
            VacaSelecionada = null;
        }

        private async Task EditarVaca()
        {
            var paramentros = new NavigationParameters
            {
                {nameof(Vaca), Vaca }
            };

            await NavigationService.NavigateAsync(nameof(CadastroVacaPage), paramentros);
        }

        private async Task ExcluirVaca()
        {
            Vaca.Deletado = true;
            Vaca.AddDataAtualizacao();

            await _vacaService.UpdateAsync(Vaca);
            await LoadAsync();
        }
    }
}
