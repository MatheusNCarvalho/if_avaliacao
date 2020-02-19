using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Services.Api;
using IFAvaliacao.Services.Interfaces;
using Refit;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public class FazendaService : IFazendaService
    {
        private readonly IFazendaRepository _fazendaRepository;

        public FazendaService(IFazendaRepository fazendaRepository)
        {
            _fazendaRepository = fazendaRepository;
        }

        public async Task PullAsync()
        {
            
        }

        public async Task PushAsync()
        {
            var fazendas = await _fazendaRepository.GetAsync();

            var fazendaApi = RestService.For<IFazendaApi>(HttpClientInstance.Current);
            await fazendaApi.PostOrPutAsync(fazendas);
        }
    }
}
