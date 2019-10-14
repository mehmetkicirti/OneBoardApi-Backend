using OneBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Core.DataAccess
{
   public interface IEntityRepository<TEntity> where TEntity:
       class,IEntity,new()
       //IEntity derived class only reach such as => User:IEntity
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        //nullable field
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void DeleteById(int ID);
        Task DeleteByIdAsync(int ID);
        TEntity Find(params object[] keyValues);

    }
}
