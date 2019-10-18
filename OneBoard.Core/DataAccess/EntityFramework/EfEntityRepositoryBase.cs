using Microsoft.EntityFrameworkCore;
using OneBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> :
        IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void DeleteById(int ID)
        {
            using (var context = new TContext())
            {
                var Entity = context.Find<TEntity>(ID);
                var DeleteEntity = context.Entry(Entity);
                DeleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Find(params object[] keyValues)
        {
            using (var context = new TContext())
            {
                return context.Find<TEntity>(keyValues);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using(var context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
                  
            }
        }

        public IQueryable<TEntity> GetListByQueryable(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().Where(filter) :
                    context.Set<TEntity>();
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity,bool>> filter = null)
        {
            using(var context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().Where(filter).ToList() :
                    context.Set<TEntity>().ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using(var context=new TContext())
            {
                var UpdateEntity = context.Entry(entity);
                UpdateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        #region Async

        public virtual async Task UpdateAsync(TEntity entity)
        {
            using(var context=new TContext())
            {
                try
                {
                    var updateEntity = context.Entry(entity);
                    updateEntity.State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }

                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }


            }
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {

                try
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
        }
        public virtual async Task DeleteByIdAsync(int ID)
        {
            using (var context = new TContext())
            {
                try
                {
                    var Entity = await context.FindAsync<TEntity>(ID);
                    var DeleteEntity = context.Entry(Entity);
                    DeleteEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
        }
        public virtual async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                try
                {
                  
                    var DeleteEntity = context.Entry(entity);
                    DeleteEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
        } 
        #endregion
    }
}
