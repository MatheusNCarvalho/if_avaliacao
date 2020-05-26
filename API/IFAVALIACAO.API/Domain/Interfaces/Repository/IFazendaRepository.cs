﻿using System;
using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Interfaces.Repository
{
    public interface IFazendaRepository : IRepository<Fazenda>
    {
        IList<Fazenda> GetByInscricoesEstaduais(Guid userId, IList<string> values);
    }
}