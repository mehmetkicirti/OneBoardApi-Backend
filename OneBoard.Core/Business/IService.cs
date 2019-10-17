using OneBoard.Core.Entity;
using OneBoard.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
