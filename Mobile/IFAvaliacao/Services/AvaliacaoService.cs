using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Api;
using IFAvaliacao.Services.Interfaces;
using Refit;
using System;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public class AvaliacaoService : ServiceBase, IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IMobileTableSchemaRepository repository, IAvaliacaoRepository avaliacaoRepository) : base(repository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public Task PullAsync()
        {
            return Task.CompletedTask;
        }

        public async Task PushAsync()
        {
            var avaliacoes = await _avaliacaoRepository.GetAsync(true);

            var avaliacaoApi = RestService.For<IAvaliacaoApi>(HttpClientInstance.Current);
            await avaliacaoApi.Post(avaliacoes);

            var tableSchema = await GetByTableSchemaAsync(nameof(AvaliacaoVaca));
            tableSchema?.SetLastSync(DateTime.Now);
            await UpdateTableSchemaAsync(tableSchema);

            foreach (var item in avaliacoes)
            {
                await _avaliacaoRepository.DeleteAsync(item);
            }
        }
    }
}
