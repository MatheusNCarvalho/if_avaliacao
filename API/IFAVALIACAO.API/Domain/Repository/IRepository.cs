using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        IList<TEntity> SearchItemsToSync(bool firstSync, DateTimeOffset? lastDateStart, string includes = null);
        IList<TEntity> Get(Expression<Func<TEntity, bool>> expression, string include = null);
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}