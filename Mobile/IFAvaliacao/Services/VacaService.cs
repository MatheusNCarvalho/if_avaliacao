using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public class VacaService : IVacaService
    {
        private readonly IVacaRepository _vacaRepository;
        private readonly IFazendaRepository _fazendaRepository;
        public VacaService(IVacaRepository vacaRepository, IFazendaRepository fazendaRepository)
        {
            _vacaRepository = vacaRepository;
            _fazendaRepository = fazendaRepository;
        }

        public async Task<bool> DeleteAsync(Vaca vaca)
        {
            return await _vacaRepository.DeleteAsync(vaca);
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
    }
}
