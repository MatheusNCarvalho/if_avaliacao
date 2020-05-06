using Acr.UserDialogs;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Interfaces;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IFAvaliacao.Views;
using Prism.Commands;

namespace IFAvaliacao.ViewModels
{
    public class PreenchimentoConcluidosViewModel : ViewModelBase, IAsyncInitialization
    {
        public Task Initialization { get; }
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        public PreenchimentoConcluidosViewModel(INavigationService navigationService, IAvaliacaoRepository avaliacaoRepository) : base(navigationService)
        {
            Title = "Concluidos";
            _avaliacaoRepository = avaliacaoRepository;
            Initialization = LoadAsync();
            AvalicaoVacaActionSheetCommand = new DelegateCommand(async () => await ExecuteAvalicaoVacaActionSheetCommand());
        }

        public DelegateCommand AvalicaoVacaActionSheetCommand { get; }

        private ObservableCollection<AvaliacaoVaca> _avaliacaoVacas;
        public ObservableCollection<AvaliacaoVaca> AvaliacaoVacas { get => _avaliacaoVacas; set => SetProperty(ref _avaliacaoVacas, value); }
        
        private AvaliacaoVaca _avaliacaoVacaItem;
        public AvaliacaoVaca AvaliacaoVacaItem { get => _avaliacaoVacaItem; set => SetProperty(ref _avaliacaoVacaItem, value); }


        public async Task LoadAsync()
        {
            var results = await _avaliacaoRepository.GetAsync();
            AvaliacaoVacas = new ObservableCollection<AvaliacaoVaca>(results);
        }


        async Task ExecuteAvalicaoVacaActionSheetCommand()
        {
            if (AvaliacaoVacaItem == null) return;

            var parameters = new NavigationParameters
            {
                {nameof(AvaliacaoVaca), AvaliacaoVacaItem }
            };

            await NavigationService.NavigateAsync(nameof(PreenchimentoPage), parameters);
        }


    }
}
