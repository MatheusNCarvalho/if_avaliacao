using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Views;
using Prism.Commands;
using Prism.Navigation;

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
            DeleteCommand = new DelegateCommand<Fazenda>(async (fazenda) => await ExecuteDeteleCommand(fazenda));
        }


        public DelegateCommand<Fazenda> DeleteCommand { get; }
        public DelegateCommand NavigatePageCommand { get; }

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

        private async Task ExecuteDeteleCommand(Fazenda fazenda)
        {
            await DialogService.AlertAsync("Teste", $"Id da Fazenda {fazenda?.Id}", "Ok");
        }
    }
}
