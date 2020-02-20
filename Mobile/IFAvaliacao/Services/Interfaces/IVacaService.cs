using IFAvaliacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Interfaces
{
    public interface IVacaService : ISyncService
    {
        Task UpdateAsync(Vaca vaca);
        Task<IList<Vaca>> GetAllAsync();
        Task<bool> ExisteVacaPorFazendaAsync(string id, string idFazenda, int numero);
        Task<bool> ExisteVacaPorNumero(string id, int numero);
        Task<bool> DeleteAsync(Vaca vaca);

    }
}
