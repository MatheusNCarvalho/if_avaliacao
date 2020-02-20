
using IFAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IFAvaliacao.Data.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase, new()
    {
        Task<IList<TEntity>> GetAsync(bool ignoreFilters = false);
        Task<TEntity> GetByIdAsync(string id, bool ignoreFilters = false);
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, bool ignoreFilters = false);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool ignoreFilters = false);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> UpdateAllAsync(IList<TEntity> entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}