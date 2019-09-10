using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Domain.Validation;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Utils.Extensions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace IFAvaliacao.ViewModels
{
    public class CadastroVacaViewModel : ViewModelBase,
        IAsyncInitialization
    {
        public Task Initialization { get; }

        private readonly IFazendaRepository _fazendaRepository;
        private readonly IVacaRepository _vacaRepository;
        public CadastroVacaViewModel(INavigationService navigationService, IFazendaRepository fazendaRepository,
            IVacaRepository vacaRepository) : base(navigationService)
        {
            Title = "Cadastro Vaca";
            _fazendaRepository = fazendaRepository;
            _vacaRepository = vacaRepository;
            Initialization = LoadFazendaAsync();
            SaveCommand = new DelegateCommand(async () => await ExecuteSaveCommand());

        }

        public DelegateCommand SaveCommand { get; }

        private string _id;
        public string Id { get => _id; set => SetProperty(ref _id, value); }

        private string _fazendaId;
        public string FazendaId { get => _fazendaId; set => SetProperty(ref _fazendaId, value); }

        private string _nome;
        public string Nome { get => _nome; set => SetProperty(ref _nome, value); }

        private int _numero;
        public int Numero { get => _numero; set => SetProperty(ref _numero, value); }

        private string _nomePai;
        public string NomePai { get => _nomePai; set => SetProperty(ref _nomePai, value); }

        private int _numeroPai;
        public int NumeroPai { get => _numeroPai; set => SetProperty(ref _numeroPai, value); }

        private string _nomeMae;
        public string NomeMae { get => _nomeMae; set => SetProperty(ref _nomeMae, value); }

        private int _numeroMae;
        public int NumeroMae { get => _numeroMae; set => SetProperty(ref _numeroMae, value); }

        private string _raca;
        public string Raca { get => _raca; set => SetProperty(ref _raca, value); }

        private string _grauSanguinio;
        public string GrauSanguinio { get => _grauSanguinio; set => SetProperty(ref _grauSanguinio, value); }

        private string _dataNascimento;
        public string DataNascimento { get => _dataNascimento; set => SetProperty(ref _dataNascimento, value); }

        /// <summary>
        /// Ordem de parto: (quantos partos a vaca teve ao longo da vida)
        /// </summary>
        private int _ordemParto;
        public int OrdemParto { get => _ordemParto; set => SetProperty(ref _ordemParto, value); }

        /// <summary>
        /// IPP (idade ao primeiro parto):
        /// </summary>
        private int _ipp;
        public int Ipp { get => _ipp; set => SetProperty(ref _ipp, value); }

        private ObservableCollection<Fazenda> _fazendas;
        public ObservableCollection<Fazenda> Fazendas { get => _fazendas; set => SetProperty(ref _fazendas, value); }

        private Fazenda _fazenda;
        public Fazenda Fazenda { get => _fazenda; set => SetProperty(ref _fazenda, value); }

        private int _fazendaIndex = -1;
        public int FazendaIndex { get => _fazendaIndex; set => SetProperty(ref _fazendaIndex, value); }


        private async Task ExecuteSaveCommand()
        {
            try
            {
                var vaca = CreateInstance();
                if (Id.HasValue())
                {

                }
                else
                {
                    var valid = await ValidateVaca(vaca);
                    if (!valid) return;
                    if (await _vacaRepository.AddAsync(vaca))
                    {
                        ToastSuccess("Cadastro realizado com sucesso!");
                        await NavigationService.GoBackAsync();
                        return;
                    }
                }
                ToastError("Ocorreu um erro ao salvar!");
            }
            catch (Exception ex)
            {
                ToastError(ex.Message);
            }
        }

        private async Task<bool> ValidateVaca(Vaca vaca)
        {
            var validator = new VacaValidation();
            var results = validator.Validate(vaca);

            if (!results.IsValid)
            {
                await DialogService.AlertAsync("Os campos abaixo, são obrigatorios: \n" +
                                     $"{string.Join("\n", results.Errors.Select(x => x.ErrorMessage))}", "Opps..", "Ok");

            }
            return results.IsValid;
        }

        private Vaca CreateInstance()
        {

            var newObj = new Vaca
            {
                FazendaId = Fazenda?.Id,
                Numero = Numero,
                Nome = Nome,
                NomeMae = NomeMae,
                NumeroMae = NumeroMae,
                NomePai = NomePai,
                NumeroPai = NumeroPai,
                Ipp = Ipp,
                OrdemParto = OrdemParto,
                Raca = Raca,
                GrauSanguinio = GrauSanguinio
            };

            if (DataNascimento.HasValue())
                newObj.DataNascimento = DateTime.Parse(DataNascimento);

            return newObj;
        }


        private async Task LoadFazendaAsync()
        {
            try
            {
                DialogService.ShowLoading("Aguarde, buscando fazendas.");
                var fazendas = await _fazendaRepository.GetAsync();
                Fazendas = new ObservableCollection<Fazenda>(fazendas);
            }
            catch (Exception ex)
            {
                DialogService.HideLoading();
                ToastError(ex.Message);
            }
            finally
            {
                DialogService.HideLoading();
            }
        }

    }
}
