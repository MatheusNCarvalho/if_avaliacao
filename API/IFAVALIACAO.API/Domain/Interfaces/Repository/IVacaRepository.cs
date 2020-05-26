using System;
using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Interfaces.Repository
{
    public interface IVacaRepository : IRepository<Vaca>
    {
        IList<Vaca> GetByNumeros(Guid userId, IList<int> numeros);
    }
}