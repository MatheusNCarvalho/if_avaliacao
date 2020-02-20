using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public class VacaService : ServiceBase, IVacaService
    {
        private readonly IVacaRepository _vacaRepository;
        private readonly IFazendaRepository _fazendaRepository;
        private readonly string Controller = "vacas";
        public VacaService(IVacaRepository vacaRepository, IFazendaRepository fazendaRepository, IMobileTableSchemaRepository mobileTableSchemaRepository) : base(mobileTableSchemaRepository)
        {
            _vacaRepository = vacaRepository;
            _fazendaRepository = fazendaRepository;
        }

        public async Task<bool> ExisteVacaPorFazendaAsync(string id, string idFazenda, int numero)
        {
            var vacaExistente = await _vacaRepository.GetAsync(x => x.Numero == numero && x.FazendaId.Equals(idFazenda));

            if (!vacaExistente.Any()) return false;

            return vacaExistente.FirstOrDefault().Id != id;
        }

        public async Task<IList<Vaca>> GetAllAsync()
        {
            var vacas = await _vacaRepository.GetAsync();

            foreach (var vaca in vacas)
            {
                vaca.Fazenda = await _fazendaRepository.GetByIdAsync(vaca.FazendaId);
            }

            return vacas;
        }

        public async Task PullAsync()
        {
            var dataSync = DateTime.Now;
            var tableSchema = await GetByTableSchemaAsync(nameof(Vaca));
            if (tableSchema == null) return;
            var response = await GetAsync<Vaca>(Controller, !tableSchema?.LastSync.HasValue ?? true, tableSchema.LastSync);

            foreach (var item in response.ToList())
            {
                var existiItem = await _vacaRepository.GetFirstOrDefaultAsync(x => x.Numero == item.Numero && x.FazendaInscricaoEstadual == item.FazendaInscricaoEstadual, true);

                if (existiItem == null)
                {
                    await _vacaRepository.AddAsync(item);
                    continue;
                }
                if (existiItem.DataAtualizacao.Value.Ticks >= item.DataAtualizacao.Value.Ticks) continue;
                await UpdateVacaAsync(existiItem, item);
            }
            tableSchema.SetLastSync(dataSync);
            await UpdateTableSchemaAsync(tableSchema);
        }

        public Task PushAsync()
        {
            return Task.CompletedTask;
        }

        public async Task<bool> DeleteAsync(Vaca vaca)
        {
            return await _vacaRepository.DeleteAsync(vaca);
        }

        public async Task UpdateAsync(Vaca vaca)
        {
            await _vacaRepository.UpdateAsync(vaca);
        }

        private async Task UpdateVacaAsync(Vaca oldValue, Vaca newValue)
        {
            oldValue.FazendaInscricaoEstadual = newValue.FazendaInscricaoEstadual;
            oldValue.Nome = newValue.Nome;
            oldValue.Numero = newValue.Numero;
            oldValue.NomePai = newValue.NomePai;
            oldValue.NumeroPai = newValue.NumeroPai;
            oldValue.NumeroVacaMae = newValue.NumeroVacaMae;
            oldValue.Raca = newValue.Raca;
            oldValue.GrauSanguinio = newValue.GrauSanguinio;
            oldValue.DataNascimento = newValue.DataNascimento;
            oldValue.OrdemParto = newValue.OrdemParto;
            oldValue.Ipp = newValue.Ipp;
            await _vacaRepository.UpdateAsync(oldValue);
        }
    }
}
