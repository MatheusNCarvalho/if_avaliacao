using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Repository
{
    public interface IFazendaRepository : IRepository<Fazenda>
    {
        IList<Fazenda> GetByInscricoesEstaduais(IList<string> values);
    }
}