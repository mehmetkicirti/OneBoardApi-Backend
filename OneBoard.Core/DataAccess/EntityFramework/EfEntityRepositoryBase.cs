using Microsoft.EntityFrameworkCore;
using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneBoard.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> :
        IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        protected readonly TContext _context;
        public EfEntityRepositoryBase(TContext context)
        {
            this._context =context;
        }

        public void Add(TEntity entity)
        {
            
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                //_context.SaveChanges();
            
                
        }

        public void Delete(TEntity entity)
        {
            using (var _context = new TContext())
            {
                var deleteEntity = _context.Entry(entity);
                deleteEntity.State = EntityState.Deleted; 
                _context.SaveChanges();
            }
        }

        public void DeleteById(int ID)
        {
            using (var _context = new TContext())
            {
                var Entity = _context.Find<TEntity>(ID);
                var DeleteEntity = _context.Entry(Entity);
                DeleteEntity.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public TEntity Find(params object[] keyValues)
        {
            using (var _context = new TContext())
            {
                return _context.Find<TEntity>(keyValues);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var _context = new TContext())
            {
                return _context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IQueryable<TEntity> GetListByQueryable(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var _context = new TContext())
            {
                return filter != null ? _context.Set<TEntity>().Where(filter) :
                    _context.Set<TEntity>();
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var _context = new TContext())
            {
                return filter != null ? _context.Set<TEntity>().Where(filter).ToList() :
                    _context.Set<TEntity>().ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var _context = new TContext())
            {
                var UpdateEntity = _context.Entry(entity);
                UpdateEntity.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }


        #region Async

        #region unneccessary async methods
        //public virtual async Task UpdateAsync(TEntity entity)
        //{
        //    using (var context = new TContext())
        //    {
        //        await context.up
        //        //var updateEntity = context.Entry(entity);
        //        //updateEntity.State = EntityState.Modified;
        //    }
        //}

        
        //public virtual async Task DeleteAsync(TEntity entity)
        //{
        //    using (var context = new TContext())
        //    {
        //            var DeleteEntity = context.Entry(entity);
        //            DeleteEntity.State = EntityState.Deleted;
        //    }
        //}
        #endregion

        public virtual async Task DeleteByIdAsync(int ID)
        {
            using (var _context = new TContext())
            {
                var Entity = await _context.FindAsync<TEntity>(ID);
                var DeleteEntity = _context.Entry(Entity);
                DeleteEntity.State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            using (var _context = new TContext())
            {
                await _context.AddAsync<TEntity>(entity);
                //await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            using (var _context = new TContext())
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> FindByIdAsync(int ID)
        {
            using (var _context = new TContext())
            {
                return await _context.FindAsync<TEntity>(ID);
            }
        }

        public async Task UpdateAsync(int ID)
        {
            using (var _context = new TContext())
            {
                var entity = await _context.FindAsync<TEntity>(ID);
                var UpdateItem = _context.Entry<TEntity>(entity);
                UpdateItem.State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
