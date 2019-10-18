using OneBoard.Core.DataAccess;
using OneBoard.Core.Entity;
using OneBoard.Core.Utilities;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Results.Concerete.Data;
using OneBoard.Core.Utilities.Results.Concerete.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneBoard.Core.Business.EFBaseService
{
    public class EfBaseService<TDal, TEntity> :
        IService<TEntity> where TEntity : class, IEntity, new()
        where TDal :IEntityRepository<TEntity>
    {

        private readonly TDal _dal;

        public EfBaseService(TDal dal)
        {
            _dal = dal;
        }

        public IResult Add(TEntity entity)
        {
            try
            {
                _dal.Add(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(TEntity entity)
        {
            try
            {
                _dal.Delete(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IDataResult<TEntity> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IQueryable<TEntity>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<TEntity>>(_dal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }

            catch (Exception e)
            {
                return new FailDataResult<IQueryable<TEntity>>(e.Message);
            }
        }

        public IDataResult<List<TEntity>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<TEntity>>(_dal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<TEntity>>(e.Message);
            }
        }

        public IResult Update(TEntity entity)
        {
            try
            {
                _dal.Update(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }
    }
}
