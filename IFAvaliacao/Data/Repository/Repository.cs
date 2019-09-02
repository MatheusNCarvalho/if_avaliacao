using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IFAvaliacao.Data.Repository
{
    public abstract  class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly ISQLitePlatform _sQLitePlatform;
        protected Repository(ISQLitePlatform sQLitePlatform)
        {
            _sQLitePlatform = sQLitePlatform;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            return (await _sQLitePlatform.GetConnectionAsync().InsertAsync(entity).ConfigureAwait(false)) > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return (await _sQLitePlatform.GetConnectionAsync().DeleteAsync(entity).ConfigureAwait(false)) > 0;
        }

        public async virtual Task<IList<TEntity>> GetAsync()
        {
            return await _sQLitePlatform.GetConnectionAsync().Table<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _sQLitePlatform.GetConnectionAsync().Table<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _sQLitePlatform.GetConnectionAsync().Table<TEntity>()
                .FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAllAsync(IList<TEntity> entity)
        {
            return (await _sQLitePlatform.GetConnectionAsync().UpdateAllAsync(entity).ConfigureAwait(false)) > 0;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return (await _sQLitePlatform.GetConnectionAsync().UpdateAsync(entity).ConfigureAwait(false)) > 0;
        }
    }
}
