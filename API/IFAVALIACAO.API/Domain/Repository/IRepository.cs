using System;
using System.Linq;
using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}