﻿using OneBoard.Business.Abstract;
using OneBoard.Core.Business.EFBaseService;
using OneBoard.Core.DataAccess;
using OneBoard.Core.Utilities;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Results.Concerete.Data;
using OneBoard.Core.Utilities.Results.Concerete.Result;
using OneBoard.DataAccess.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Business.Concrete
{
    public class SerieManager : BaseService<ISerieDal, Serie>, ISerieService
    {
        public SerieManager(ISerieDal dal, IUnitOfWork unitOfWork) : base(dal, unitOfWork)
        {
        }

        #region nonasync
        public IResult Add(Serie entity)
        {
            try
            {
                _dal.Add(entity);
                _unitOfWork.Complete();
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception e)
            {

                return new FailResult($"{BasicCrudOperationMessages.FAIL_ADD} : \n {e.Message }");
            }
        }
        public IDataResult<Serie> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Serie>(_dal.Find(Id),
                    BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {

                return new FailDataResult<Serie>(e.Message);
            }
        }
        public IResult Update(Serie entity)
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

        public IDataResult<IQueryable<Serie>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<Serie>>(_dal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }

            catch (Exception e)
            {
                return new FailDataResult<IQueryable<Serie>>(e.Message);
            }
        }

        public IDataResult<List<Serie>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<Serie>>(_dal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<Serie>>(e.Message);
            }
        }

        public IResult Delete(Serie entity)
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
                return new FailResult($"{BasicCrudOperationMessages.FAIL_DELETE} : \n {e.Message}");
            }
        }
        #endregion

        #region async
        public async Task<IResult> AddAsync(Serie entity)
        {
            try
            {
                await _dal.AddAsync(entity);
                await _unitOfWork.CompleteAsync();

                return new SuccessDataResult<Serie>(entity, BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public async Task<IResult> DeleteByIdAsync(int Id)
        {
            try
            {
                Serie entity = await _dal.FindByIdAsync(Id);
                if (entity == null)
                {
                    return new FailDataResult<Serie>($"{BasicCrudOperationMessages.NOT_FOUND_ENTİTY} :That belonging to {Id} any entity.");
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

        public async Task<IDataResult<Serie>> FindByIdAsync(int Id)
        {
            try
            {
                Serie entity = await _dal.FindByIdAsync(Id);
                if (entity == null)
                {
                    return new FailDataResult<Serie>($"{BasicCrudOperationMessages.NOT_FOUND_ENTİTY} :That belonging to {Id} any entity.");
                }
                return new SuccessDataResult<Serie>(entity, $"{BasicCrudOperationMessages.SUCCESS_GET_ID}");
            }
            catch (Exception ex)
            {
                return new FailDataResult<Serie>($"{BasicCrudOperationMessages.FIND_BY_ID_ERROR} :Exception : {ex.Message}");
            }
        }

        public async Task<IDataResult<IList<Serie>>> GetEntityValuesAsync()
        {
            try
            {
                //filling entity list
                IEnumerable<Serie> entities = await _dal.ListAsync();
                return new SuccessDataResult<IList<Serie>>(entities.ToList(), $"{BasicCrudOperationMessages.SUCCESS_GET_LİST}");
            }
            catch (Exception ex)
            {

                return new FailDataResult<IList<Serie>>($"There is an error.When it finding the list : {ex.Message}");
            }
        }

        public async Task<IResult> UpdateAsync(Serie entity)
        {
            try
            {
                ////TEntity entity = await _dal.FindByIdAsync(Id);
                ////if (entity == null)
                ////{
                ////    return new FailDataResult<TEntity>($"{BasicCrudOperationMessages.NOT_FOUND_ENTİTY} :That belonging to {Id} any entity.");
                ////}
                //else
                //{
                await _dal.UpdateAsync(entity);
                await _unitOfWork.CompleteAsync();
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);

            }
            catch (Exception ex)
            {
                return new FailResult(ex.Message);
            }
        }
        #endregion
    }
}
