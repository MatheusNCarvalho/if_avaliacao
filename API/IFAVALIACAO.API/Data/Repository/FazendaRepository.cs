using System;
using System.Collections.Generic;
using System.Linq;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Interfaces.Repository;

namespace IFAVALIACAO.API.Data.Repository
{
    public class FazendaRepository : Repository<Fazenda>, IFazendaRepository
    {
        public FazendaRepository(IFDbContext context) : base(context)
        {
        }

        public IList<Fazenda> GetByInscricoesEstaduais(Guid userId, IList<string> values)
        {
            return GetAll().Where(x => x.UserId == userId && values.Contains(x.InscricaoEstadual)).ToList();
        }
    }
}