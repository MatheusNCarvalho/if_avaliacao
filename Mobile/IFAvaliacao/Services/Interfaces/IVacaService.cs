using IFAvaliacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Interfaces
{
    public interface IVacaService
    {
        Task<IList<Vaca>> GetAllAsync();
        Task<bool> DeleteAsync(Vaca vaca);
        Task<bool> ExisteVacaPorFazendaAsync(string id, string idFazenda, int numero);
    }
}
