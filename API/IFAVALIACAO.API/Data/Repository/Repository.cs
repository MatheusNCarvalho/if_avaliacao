using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Extension;
using IFAVALIACAO.API.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace IFAVALIACAO.API.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly IFDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(IFDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IList<TEntity> GetByIds(IList<Guid> ids)
        {
            return GetAll().Where(x => ids.Contains(x.Id)).ToList();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public IList<TEntity> SearchItemsToSync(Guid userId, bool firstSync, DateTimeOffset? lastDateStart, string includes = null)
        {
            var query = GetAll();


            if (!firstSync && lastDateStart.HasValue)
            {
                query = query.Where(x => x.DataCriacao >= lastDateStart.Value.LocalDateTime ||
                                         x.DataAtualizacao >= lastDateStart.Value.LocalDateTime);
            }

            query = query.Where(x => x.UserId == userId);

            if (includes.HasValue())
            {
                query = query.Include(includes);
            }

            query = query.OrderByDescending(x => x.DataCriacao);
            return query.ToList();
        }

        public IList<TEntity> Get(Expression<Func<TEntity, bool>> expression, string include = null)
        {
            var query = GetAll();

            if (include.HasValue())
            {
                var includes = include.Split(',');
                foreach (var incl in includes)
                {
                    query = query.Include(incl);
                }
            }

            query = query.Where(expression);
            return query.ToList();
        }



        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
            Context.Entry(obj).Property(x => x.DataCriacao).IsModified = false;
        }

        public virtual void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
                DbSet.Remove(obj);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}