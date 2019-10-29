using Acr.UserDialogs;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Interfaces;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
        }


        private ObservableCollection<AvaliacaoVaca> _avaliacaoVacas;
        public ObservableCollection<AvaliacaoVaca> AvaliacaoVacas { get => _avaliacaoVacas; set => SetProperty(ref _avaliacaoVacas, value); }



        public async Task LoadAsync()
        {
            var results = await _avaliacaoRepository.GetAsync();
            AvaliacaoVacas = new ObservableCollection<AvaliacaoVaca>(results);
        }

    }
}
