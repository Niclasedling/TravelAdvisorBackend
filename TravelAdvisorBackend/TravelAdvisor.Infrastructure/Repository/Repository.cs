using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.Data;

namespace TravelAdvisor.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbApplicationContext context;

        public Repository(DbApplicationContext context)
        {
            this.context = context;
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await context.Set<TEntity>().AddRangeAsync(entities);

        public async Task RemoveAsync(TEntity entity) => await Task.Run(() => { context.Set<TEntity>().Remove(entity); });

        public async Task UpdateAsync(TEntity entity) => await Task.Run(() => { context.Set<TEntity>().Update(entity); });

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities) => await Task.Run(() => { context.Set<TEntity>().RemoveRange(entities); });

        public async Task<TEntity> GetByGuidAsync(Guid id) => await context.Set<TEntity>().FindAsync(id);
        public async Task<IList<TResult>> GetByGuidAsync<TResult>(
                                            Expression<Func<TEntity, TResult>> selector,
                                            Expression<Func<TEntity, bool>> predicate = null, 
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (predicate != null) { query = query.Where(predicate); }
            if (include != null) { query = include(query); }

            return await query.Select(selector).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Task.Run(() => {  return context.Set<TEntity>().ToList(); });

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) => await Task.Run(() => { return context.Set<TEntity>().Where(predicate); });

        public virtual async Task<IList<TResult>> ListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                              Expression<Func<TEntity, bool>> predicate = null,
                                              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                              Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                              bool disableTracking = true, int? skip = null, int? take = null)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (disableTracking) { query = query.AsNoTracking(); }
            if (include != null) { query = include(query); }
            if (predicate != null) { query = query.Where(predicate); }
            if (orderBy != null) { query = orderBy(query); }
            if (skip != null) { query = query.Skip(skip.Value); }
            if (take != null) { query = query.Take(take.Value); }

            return await query.Select(selector).ToListAsync();
        }

    }
}
