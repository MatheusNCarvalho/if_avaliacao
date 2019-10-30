using System;
using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {

    }
}