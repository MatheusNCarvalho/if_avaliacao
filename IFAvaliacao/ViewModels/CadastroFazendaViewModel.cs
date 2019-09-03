using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Utils.Extensions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace IFAvaliacao.ViewModels
{
    public class CadastroFazendaViewModel : ViewModelBase
    {
        private readonly IFazendaRepository _fazendaRepository;
        public CadastroFazendaViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
            IFazendaRepository fazendaRepository) : base(navigationService, pageDialogService)
        {
            Title = "Cadastro de fazenda";
            _fazendaRepository = fazendaRepository;
            RegisterCommand = new DelegateCommand(async () => await ExecuteSaveCommand());
        }

        public DelegateCommand RegisterCommand { get; }

        private string _id;
        public string Id { get => _id; set => SetProperty(ref _id, value); }

        private string _inscricaoEstadual;
        public string InscricaoEstadual { get => _inscricaoEstadual; set => SetProperty(ref _inscricaoEstadual, value); }

        private string _nome;
        public string Nome { get => _nome; set => SetProperty(ref _nome, value); }

        private string _nomeFazenda;
        public string NomeFazenda { get => _nomeFazenda; set => SetProperty(ref _nomeFazenda, value); }

        private string _cep;
        public string Cep { get => _cep; set => SetProperty(ref _cep, value); }

        private string _rua;
        public string Rua { get => _rua; set => SetProperty(ref _rua, value); }

        private string _bairro;
        public string Bairro { get => _bairro; set => SetProperty(ref _bairro, value); }

        private string _cidade;
        public string Cidade { get => _cidade; set => SetProperty(ref _cidade, value); }

        private string _estado;
        public string Estado { get => _estado; set => SetProperty(ref _estado, value); }

        private async Task ExecuteSaveCommand()
        {

            try
            {
                if (Id.HasValue())
                {
                    var fazenda = new Fazenda(InscricaoEstadual, Nome, NomeFazenda, Cep, Rua, Bairro, Cidade, Estado);
                    fazenda.AddId(Id);
                    await _fazendaRepository.UpdateAsync(fazenda);
                }
                else
                {
                    var fazenda = new Fazenda(InscricaoEstadual, Nome, NomeFazenda, Cep, Rua, Bairro, Cidade, Estado);
                    await _fazendaRepository.AddAsync(fazenda);
                }
            }
            catch (Exception e)
            {

            }

        }
    }
}
