using OneBoard.Core.DataAccess;
using OneBoard.Core.Utilities;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Results.Concerete.Data;
using OneBoard.Core.Utilities.Results.Concerete.Result;
using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Core.Business.EFBaseService
{
    public class EfBaseService<TDal, TEntity> :
        IService<TEntity> where TEntity : class, IEntity, new()
        where TDal : IEntityRepository<TEntity>
    {
        protected readonly TDal _dal;
        protected readonly IUnitOfWork _unitOfWork;

        public EfBaseService(TDal dal, IUnitOfWork unitOfWork)
        {
            _dal = dal;
            _unitOfWork = unitOfWork;
        }
        public EfBaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IResult Add(TEntity entity)
        {
            try
            {

                _dal.Add(entity);

                _unitOfWork.Complete();

                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }

            catch (Exception e)
            {
                return new FailResult($"{BasicCrudOperationMessages.FAIL_ADD} : {e.Message}");
            }
        }

        public IResult Delete(TEntity entity)
        {
            try
            {
                _dal.Delete(entity);
                //Here it is before completeasync execute method what ever you want.So that it is necessary. 
                _unitOfWork.Complete();
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }

            catch (Exception e)
            {
                return new FailResult($"{BasicCrudOperationMessages.FAIL_DELETE} : {e.Message}");
            }
        }

        public IDataResult<TEntity> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<TEntity>(_dal.Find(Id),
                    BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {

                return new FailDataResult<TEntity>(e.Message);
            }
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
                _unitOfWork.Complete();
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }

            catch (Exception e)
            {
                return new FailResult($"{BasicCrudOperationMessages.FAIL_UPDATE} : {e.Message}");
            }
        }



        #region async
        public async Task<IResult> AddAsync(TEntity entity)
        {
            try
            {
                await _dal.AddAsync(entity);
                await _unitOfWork.CompleteAsync();

                return new SuccessDataResult<TEntity>(entity, BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }
        public async Task<IResult> UpdateAsync(int Id)
        {
            try
            {
                TEntity entity = await _dal.FindByIdAsync(Id);
                if (entity == null)
                {
                    return new FailDataResult<TEntity>($"{BasicCrudOperationMessages.NOT_FOUND_ENTİTY} :That belonging to {Id} any entity.");
                }
                else
                {
                    await _dal.UpdateAsync(Id);
                    await _unitOfWork.CompleteAsync();
                    return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
                }
            }
            catch (Exception ex)
            {
                return new FailResult(ex.Message);
            }
        }
        public async Task<IDataResult<IList<TEntity>>> GetEntityValuesAsync()
        {
            try
            {
                //filling entity list
                IEnumerable<TEntity> entities = await _dal.ListAsync();
                return new SuccessDataResult<IList<TEntity>>(entities.ToList(), $"{BasicCrudOperationMessages.SUCCESS_GET_LİST}");
            }
            catch (Exception ex)
            {

                return new FailDataResult<IList<TEntity>>($"There is an error.When it finding the list : {ex.Message}");
            }
        }

        public async Task<IResult> DeleteByIdAsync(int Id)
        {
            try
            {
                TEntity entity = await _dal.FindByIdAsync(Id);
                if (entity == null)
                {
                    return new FailDataResult<TEntity>($"{BasicCrudOperationMessages.NOT_FOUND_ENTİTY} :That belonging to {Id} any entity.");
                }
                else
                {
                    await _dal.DeleteByIdAsync(Id);
                    await _unitOfWork.CompleteAsync();
                    return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
                }
            }
            catch (Exception ex)
            {

                return new FailResult($"{ex.Message}");
            }
        }

        public async Task<IDataResult<TEntity>> FindByIdAsync(int Id)
        {
            try
            {
                TEntity entity = await _dal.FindByIdAsync(Id);
                if (entity == null)
                {
                    return new FailDataResult<TEntity>($"{BasicCrudOperationMessages.NOT_FOUND_ENTİTY} :That belonging to {Id} any entity.");
                }
                return new SuccessDataResult<TEntity>(entity, $"{BasicCrudOperationMessages.SUCCESS_GET_ID}");
            }
            catch (Exception ex)
            {
                return new FailDataResult<TEntity>($"{BasicCrudOperationMessages.FIND_BY_ID_ERROR} :Exception : {ex.Message}");
            }
        }

        #endregion








        #region virtual Extend Methods

       public virtual IResult AddByVirtualMethod(TEntity entity)
       { 
            throw new NotImplementedException();
       }

        public virtual IResult DeleteByVirtualMethod(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IResult UpdateByVirtualMethod(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IDataResult<List<TEntity>> GetListByVirtualMethod()
        {
            throw new NotImplementedException();
        }

        public virtual IDataResult<IQueryable<TEntity>> GetQueryableByVirtualMethod()
        {
            throw new NotImplementedException();
        }

        public virtual Task<IResult> AddAsyncByVirtualMethod(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IResult> DeleteAsyncByVirtualMethod(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IResult> UpdateAsyncByVirtualMethod(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IDataResult<IList<TEntity>>> GetEntityValuesAsyncByVirtualMethod()
        {
            throw new NotImplementedException();
        }








        #endregion










    }
}
