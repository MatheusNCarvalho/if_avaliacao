using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Api;
using IFAvaliacao.Services.Interfaces;
using Refit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public class FazendaService : ServiceBase, IFazendaService
    {
        private readonly IFazendaRepository _fazendaRepository;
        private readonly string Controller = "fazendas";

        public FazendaService(IFazendaRepository fazendaRepository, IMobileTableSchemaRepository repository) : base(repository)
        {
            _fazendaRepository = fazendaRepository;
        }

        public async Task PullAsync()
        {
            var dataSync = DateTime.Now;
            var tableSchema = await GetByTableSchemaAsync(nameof(Fazenda));
            if (tableSchema == null) return;
            var response = await GetAsync<Fazenda>(Controller, !tableSchema?.LastSync.HasValue ?? true, tableSchema.LastSync);

            foreach (var item in response.ToList())
            {
                var existiItem = await _fazendaRepository.GetFirstOrDefaultAsync(x => x.InscricaoEstadual == item.InscricaoEstadual, true);

                if (existiItem == null)
                {
                    await _fazendaRepository.AddAsync(item);
                    continue;
                }
                if (existiItem.DataAtualizacao.Value.Ticks >= item.DataAtualizacao.Value.Ticks) continue;
                await _fazendaRepository.UpdateAsync(item);
            }
            tableSchema.SetLastSync(dataSync);
            await UpdateTableSchemaAsync(tableSchema);
        }

        public async Task PushAsync()
        {
            var fazendas = await _fazendaRepository.GetAsync(true);

            var fazendaApi = RestService.For<IFazendaApi>(HttpClientInstance.Current);
            await fazendaApi.PostOrPutAsync(fazendas);

            var tableSchema = await GetByTableSchemaAsync(nameof(Fazenda));
            tableSchema?.SetLastSync(DateTime.Now);
            await UpdateTableSchemaAsync(tableSchema);
        }
    }
}
