using IFAvaliacao.Domain.Entities;
using System.Threading.Tasks;

namespace IFAvaliacao.Data.Repository.Interfaces
{
    public interface IFazendaRepository : IRepository<Fazenda>
    {
        Task<bool> ExisteFazendaPorInscricaoEstadual(string inscricao, string id);
    }
}
