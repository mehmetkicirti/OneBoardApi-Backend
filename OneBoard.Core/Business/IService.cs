using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Core.Business
{
    public interface IService<TEntity> where TEntity:class,IEntity,new()
    {
        IResult Add(TEntity entity);

        IResult Update(TEntity entity);

        IResult Delete(TEntity entity);

        IDataResult<List<TEntity>> GetEntityValues();

        IDataResult<TEntity> GetById(int Id);

        IDataResult<IQueryable<TEntity>> GetEntityQueryable();

        #region async service
        Task<IDataResult<IList<TEntity>>> GetEntityValuesAsync();

        Task<IResult> AddAsync(TEntity entity);

        //Task<IResult> DeleteAsync(TEntity entity);

        Task<IResult> DeleteByIdAsync(int Id);

        Task<IResult> UpdateAsync(TEntity entity);

        Task<IDataResult<TEntity>> FindByIdAsync(int Id);
        #endregion


    }
}
