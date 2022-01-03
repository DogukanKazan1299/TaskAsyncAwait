using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public async Task AddByAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                context.SaveChanges();
                await Task.CompletedTask;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deleted = context.Entry(entity);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task DeleteByAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deleted = context.Entry(entity);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
                await Task.CompletedTask;
            }
        }

        //await context.Set<TEntity>().AddAsync(entity);



        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context=new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context=new TContext())
            {
                return filter == null ?
                    await context.Set<TEntity>().ToListAsync() :
                    await context.Set<TEntity>().Where(filter).ToListAsync();
                    
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (var context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> expression)
        {
            using (var context=new TContext())
            {
                var result = await Task.FromResult(context.Set<TEntity>().SingleOrDefault(expression));
                return result;
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public async Task UpdateByAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                context.SaveChanges();
                await Task.CompletedTask;
            }
        }
    }
}
