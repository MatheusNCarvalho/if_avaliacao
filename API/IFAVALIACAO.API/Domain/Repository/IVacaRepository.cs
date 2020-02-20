﻿using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Repository
{
    public interface IVacaRepository : IRepository<Vaca>
    {
        IList<Vaca> GetByNumeros(IList<int> numeros);
    }
}