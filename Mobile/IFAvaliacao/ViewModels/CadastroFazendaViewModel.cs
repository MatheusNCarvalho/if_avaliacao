using Acr.UserDialogs;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Domain.Validation;
using IFAvaliacao.Extensions;
using IFAvaliacao.Services.Api;
using Prism.Commands;
using Prism.Navigation;
using Refit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IFAvaliacao.ViewModels
{
    public class CadastroFazendaViewModel : ViewModelBase
    {
        private readonly IFazendaRepository _fazendaRepository;
        private readonly IFindZipCodeApi _findZipCodeApi;
        public CadastroFazendaViewModel(INavigationService navigationService, IFazendaRepository fazendaRepository) : base(navigationService)
        {
            Title = "Cadastro de fazenda";
            _fazendaRepository = fazendaRepository;
            _findZipCodeApi = RestService.For<IFindZipCodeApi>("https://viacep.com.br/ws");
            RegisterCommand = new DelegateCommand(async () => await ExecuteSaveCommand());
        }

        public DelegateCommand RegisterCommand { get; }

        private string _id;
        public string Id { get => _id; set => SetProperty(ref _id, value); }

        public DateTime DataCriacao { get; set; }

        private string _inscricaoEstadual;
        public string InscricaoEstadual { get => _inscricaoEstadual; set => SetProperty(ref _inscricaoEstadual, value); }

        private string _nome;
        public string Nome { get => _nome; set => SetProperty(ref _nome, value); }

        private string _nomeFazenda;
        public string NomeFazenda { get => _nomeFazenda; set => SetProperty(ref _nomeFazenda, value); }

        private string _cep;
        public string Cep { get => _cep; set => SetProperty(ref _cep, value); }

        private string _endereco;
        public string Endereco { get => _endereco; set => SetProperty(ref _endereco, value); }

        private string _cidade;
        public string Cidade { get => _cidade; set => SetProperty(ref _cidade, value); }

        private string _estado;
        public string Estado { get => _estado; set => SetProperty(ref _estado, value); }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var fazenda = (Fazenda)parameters[nameof(Fazenda)];
            if (fazenda != null)
                MontarViewEdit(fazenda);


            base.OnNavigatedTo(parameters);
        }      


        private async Task ExecuteSaveCommand()
        {

            try
            {
                var fazenda = CreateNewInstancia();
                if (await _fazendaRepository.ExisteFazendaPorInscricaoEstadual(InscricaoEstadual, Id))
                {
                    await DialogService.AlertAsync($"Inscrição Estadual '{InscricaoEstadual}', já esta vinculada há uma fazenda.", "Ops...", "Ok");
                    return;
                }
                var result = await ValidateFazenda(fazenda);
                if (!result) return;

                if (Id.HasValue())
                {
                    fazenda.SetId(Id);
                    fazenda.AddDataCriacao(DataCriacao);
                    if (await _fazendaRepository.UpdateAsync(fazenda))
                    {
                        ToastSuccess("Cadastro atualizado com sucesso!");
                        await NavigationService.GoBackAsync();
                        return;
                    }

                }

                fazenda.AddDataCriacao();
                if (await _fazendaRepository.AddAsync(fazenda))
                {
                    ToastSuccess("Cadastro realizado com sucesso!");
                    await NavigationService.GoBackAsync();
                    return;
                }


                ToastError("Ocorreu um erro ao cadastrar fazenda!");
            }
            catch (Exception e)
            {
                ToastError(e.Message);
            }

        }
        private async Task<bool> ValidateFazenda(Fazenda fazenda)
        {
            var validator = new FazendaValidation();
            var results = validator.Validate(fazenda);

            if (!results.IsValid)
            {
                await DialogService.AlertAsync("Os campos abaixo, são obrigatorios: \n" +
                                     $"{string.Join("\n", results.Errors.Select(x => x.ErrorMessage))}", "Opps..", "Ok");

            }
            return results.IsValid;
        }
        private Fazenda CreateNewInstancia()
        {
            return new Fazenda
            {
                InscricaoEstadual = InscricaoEstadual,
                Nome = Nome,
                NomeFazenda = NomeFazenda,
                Cep = Cep,
                Endereco = Endereco,
                Cidade = Cidade,
                Estado = Estado
            };
        }

        private void MontarViewEdit(Fazenda fazenda)
        {
            Id = fazenda.Id;
            Nome = fazenda.Nome;
            NomeFazenda = fazenda.NomeFazenda;
            InscricaoEstadual = fazenda.InscricaoEstadual;
            Cep = fazenda.Cep;
            Endereco = fazenda.Endereco;
            Cidade = fazenda.Cidade;
            Estado = fazenda.Estado;
            DataCriacao = fazenda.DataCriacao;
        }

        public IUserDialogs UserDialogService() => DialogService;
    }
}
