﻿using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Repository;

namespace IFAVALIACAO.API.Data.Repository
{
    public class AvaliacaoRepository : Repository<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(IFDbContext context) : base(context)
        {
        }
    }
}