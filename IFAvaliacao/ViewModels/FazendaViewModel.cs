using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;
using Acr.UserDialogs;

namespace IFAvaliacao.ViewModels
{
    public class FazendaViewModel : ViewModelBase
    {
        private readonly IFazendaRepository _fazendaRepository;
        public FazendaViewModel(INavigationService navigationService, IFazendaRepository fazendaRepository) : base(navigationService)
        {
            _fazendaRepository = fazendaRepository;
            Title = "Fazendas";
            NavigatePageCommand = new DelegateCommand(async () => await NavigateToCadastroPage());
            Fazendas = new ObservableCollection<Fazenda>();
            FazedaActionsCommand = new DelegateCommand(async () => await ExecuteFazendaActionsCommand());
        }


        public DelegateCommand FazedaActionsCommand { get; }
        public DelegateCommand NavigatePageCommand { get; }

        private Fazenda _fazendaSelectionItem;
        public Fazenda FazendaSelectionItem { get => _fazendaSelectionItem; set => SetProperty(ref _fazendaSelectionItem, value); }

        public Fazenda Fazenda { get; set; }

        private ObservableCollection<Fazenda> _fazendas;
        public ObservableCollection<Fazenda> Fazendas { get => _fazendas; set => SetProperty(ref _fazendas, value); }

        public async Task LoadAsync()
        {
            var fazendas = await _fazendaRepository.GetAsync();
            Fazendas = new ObservableCollection<Fazenda>(fazendas);
        }

        private async Task NavigateToCadastroPage()
        {
            await NavigationService.NavigateAsync(nameof(CadastroFazendaPage));
        }

        private async Task ExecuteFazendaActionsCommand()
        {
            if (FazendaSelectionItem == null) return;

            var actionConfig = new ActionSheetConfig()
                .SetTitle("Escolha uma opção para continuar.")
                .SetCancel("Cancelar.")
                .Add($"Editar fazenda {FazendaSelectionItem?.NomeFazenda}.", async () => await EditarFazenda())
                .Add($"Deletar fazenda {FazendaSelectionItem?.NomeFazenda}.", async () => await DeletarFazenda())
                .SetUseBottomSheet(true);
            DialogService.ActionSheet(actionConfig);
            Fazenda = FazendaSelectionItem;
            FazendaSelectionItem = null;
        }

        private async Task EditarFazenda()
        {
            var paramenters = new NavigationParameters();
            paramenters.Add(nameof(Fazenda), Fazenda);
            await NavigationService.NavigateAsync(nameof(CadastroFazendaPage), paramenters);
        }

        private async Task DeletarFazenda()
        {
            await _fazendaRepository.DeleteAsync(Fazenda);
            await LoadAsync();
        }
    }
}
