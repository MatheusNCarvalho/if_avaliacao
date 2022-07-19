using System;
using System.Collections.Generic;
using System.Linq;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace IFAVALIACAO.API.Data.Repository
{
    public class VacaRepository : Repository<Vaca>, IVacaRepository
    {
        public VacaRepository(IFDbContext context) : base(context)
        {
        }

        public IList<Vaca> GetByNumeros(Guid userId, IList<int> numeros)
        {
            var query = GetAll();
            query = query.Include(x => x.Fazenda);
            query = query.Where(x => x.UserId == userId && numeros.Contains(x.Numero));
            return query.ToList();
        }
    }
}