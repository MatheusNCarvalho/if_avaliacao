
using IFAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IFAvaliacao.Data.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase, new()
    {
        Task<IList<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(string id);
        //IList<TEntity> Get(Func<T, bool> predicate);
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> UpdateAllAsync(IList<TEntity> entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
