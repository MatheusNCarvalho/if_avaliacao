using System.Collections.Generic;
using System.Linq;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Repository;

namespace IFAVALIACAO.API.Data.Repository
{
    public class FazendaRepository : Repository<Fazenda>, IFazendaRepository
    {
        public FazendaRepository(IFDbContext context) : base(context)
        {
        }

        public IList<Fazenda> GetByInscricoesEstaduais(IList<string> values)
        {
            return GetAll().Where(x => values.Contains(x.InscricaoEstadual)).ToList();
        }
    }
}