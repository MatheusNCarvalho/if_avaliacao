using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Domain.Validation;
using IFAvaliacao.Extensions;
using IFAvaliacao.Services.Interfaces;
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
        private readonly IVacaService _vacaService;
        public CadastroVacaViewModel(INavigationService navigationService, IFazendaRepository fazendaRepository,
            IVacaRepository vacaRepository, IVacaService vacaService) : base(navigationService)
        {
            Title = "Cadastro Vaca";
            _fazendaRepository = fazendaRepository;
            _vacaRepository = vacaRepository;
            _vacaService = vacaService;
            Initialization = LoadAsync();
            SaveCommand = new DelegateCommand(async () => await ExecuteSaveCommand());

        }

        public DelegateCommand SaveCommand { get; }

        private string _id;
        public string Id { get => _id; set => SetProperty(ref _id, value); }

        public DateTime DataCriacao { get; set; }

        private string _fazendaId;
        public string FazendaId { get => _fazendaId; set => SetProperty(ref _fazendaId, value); }

        private string _nome;
        public string Nome { get => _nome; set => SetProperty(ref _nome, value); }

        private int _numero;
        public int Numero { get => _numero; set => SetProperty(ref _numero, value); }

        private string _nomePai;
        public string NomePai { get => _nomePai; set => SetProperty(ref _nomePai, value); }

        private int? _numeroPai;
        public int? NumeroPai { get => _numeroPai; set => SetProperty(ref _numeroPai, value); }

        private string _raca;
        public string Raca { get => _raca; set => SetProperty(ref _raca, value); }

        private string _grauSanguinio;
        public string GrauSanguinio { get => _grauSanguinio; set => SetProperty(ref _grauSanguinio, value); }

        private string _dataNascimento;
        public string DataNascimento { get => _dataNascimento; set => SetProperty(ref _dataNascimento, value); }

        /// <summary>
        /// Ordem de parto: (quantos partos a vaca teve ao longo da vida)
        /// </summary>
        private int? _ordemParto;
        public int? OrdemParto { get => _ordemParto; set => SetProperty(ref _ordemParto, value); }

        /// <summary>
        /// IPP (idade ao primeiro parto):
        /// </summary>
        private int? _ipp;
        public int? Ipp { get => _ipp; set => SetProperty(ref _ipp, value); }

        private ObservableCollection<Fazenda> _fazendas;
        public ObservableCollection<Fazenda> Fazendas { get => _fazendas; set => SetProperty(ref _fazendas, value); }

        private Fazenda _fazenda;
        public Fazenda Fazenda { get => _fazenda; set => SetProperty(ref _fazenda, value); }

        private int _fazendaIndex = -1;
        public int FazendaIndex { get => _fazendaIndex; set => SetProperty(ref _fazendaIndex, value); }

        private ObservableCollection<Vaca> _vacas;
        public ObservableCollection<Vaca> Vacas { get => _vacas; set => SetProperty(ref _vacas, value); }

        private Vaca _vacaSelecionada;
        public Vaca VacaSelecionada { get => _vacaSelecionada; set => SetProperty(ref _vacaSelecionada, value); }

        private int _vacaIndex = -1;
        public int VacaIndex { get => _vacaIndex; set => SetProperty(ref _vacaIndex, value); }

        private bool _existeVacas;
        public bool ExisteVacas { get => _existeVacas; set => SetProperty(ref _existeVacas, value); }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var vaca = (Vaca)parameters[nameof(Vaca)];
            if (vaca != null)
                MontarView(vaca);

            base.OnNavigatedTo(parameters);
        }


        private async Task ExecuteSaveCommand()
        {
            try
            {
                var vaca = CreateInstance();
                var valid = await ValidateVaca(vaca);
                if (!valid) return;

                if (await _vacaService.ExisteVacaPorFazendaAsync(Id, vaca.FazendaId, Numero))
                {
                    await DialogService.AlertAsync("O numero informado já esta vinculado há outro cadastro!", "Alerta", "Ok");
                    return;
                }

                if (Id.HasValue())
                {
                    vaca.SetId(Id);
                    vaca.AddDataCriacao(DataCriacao);
                    vaca.AddDataAtualizacao();
                    if (await _vacaRepository.UpdateAsync(vaca))
                    {
                        ToastSuccess("Cadastro atualizado com sucesso!");
                        await NavigationService.GoBackAsync();
                        return;
                    }
                }

                if (await _vacaRepository.AddAsync(vaca))
                {
                    ToastSuccess("Cadastro realizado com sucesso!");
                    await NavigationService.GoBackAsync();
                    return;
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
                FazendaInscricaoEstadual = Fazenda?.InscricaoEstadual,
                Numero = Numero,
                Nome = Nome,
                VacaMaeId = VacaSelecionada?.Id,
                NumeroVacaMae = VacaSelecionada?.Numero,
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


        private async void MontarView(Vaca vaca)
        {
            Id = vaca.Id;
            FazendaId = vaca.FazendaId;
            Fazenda = await _fazendaRepository.GetByIdAsync(FazendaId);
            FazendaIndex = Fazendas.ToList().FindIndex(x => x.Id.Equals(FazendaId));
            if (vaca.VacaMaeId.HasValue())
            {
                VacaSelecionada = await _vacaRepository.GetByIdAsync(vaca.VacaMaeId);
                VacaIndex = Vacas.ToList().FindIndex(x => x.Id.Equals(VacaSelecionada.Id));              
            }
            var vacaIndexAtual = Vacas.ToList().FindIndex(x => x.Id.Equals(Id));
            Vacas.RemoveAt(vacaIndexAtual);

            Nome = vaca.Nome;
            Numero = vaca.Numero;
            NomePai = vaca.NomePai;
            NumeroPai = vaca.NumeroPai;
            Ipp = vaca.Ipp;
            OrdemParto = vaca.OrdemParto;
            Raca = vaca.Raca;
            GrauSanguinio = vaca.GrauSanguinio;
        }

        private async Task LoadAsync()
        {
            try
            {
                DialogService.ShowLoading("Aguarde, buscando fazendas e vacas mães.");
                var fazendas = await _fazendaRepository.GetAsync();
                var vacas = await _vacaRepository.GetAsync();
                Fazendas = new ObservableCollection<Fazenda>(fazendas);
                Vacas = new ObservableCollection<Vaca>(vacas);
                ExisteVacas = Vacas.Any();
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
