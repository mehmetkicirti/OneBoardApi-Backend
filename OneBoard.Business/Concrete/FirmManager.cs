using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneBoard.Business.Abstract;
using OneBoard.Business.ValidationRules._FluentValidation;
using OneBoard.Core.Aspects.Autofac.Logging;
using OneBoard.Core.Aspects.Autofac.Validation;
using OneBoard.Core.Business.EFBaseService;
using OneBoard.Core.CrossCuttingCornces.Logging.Log4Net.Loggers;
using OneBoard.Core.DataAccess;
using OneBoard.Core.Utilities;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Results.Concerete.Data;
using OneBoard.Core.Utilities.Results.Concerete.Result;
using OneBoard.DataAccess.Abstract;
using OneBoard.Entities.Concrete;

namespace OneBoard.Business.Concrete
{

    [LogAspect(typeof(DatabaseLogger))]
    [ValidationAspect(typeof(FirmValidator))]
    
    public class FirmManager : BaseService<IFirmDal, Firm>, IFirmService
    {
        public FirmManager(IFirmDal dal, IUnitOfWork unitOfWork) : base(dal, unitOfWork)
        {
        }

        #region NonAsync
        public IResult Add(Firm entity)
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

        public IDataResult<Firm> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Firm>(_dal.Find(Id),
                    BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {

                return new FailDataResult<Firm>(e.Message);
            }
        }

        public IDataResult<IQueryable<Firm>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<Firm>>(_dal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }

            catch (Exception e)
            {
                return new FailDataResult<IQueryable<Firm>>(e.Message);
            }
        }

        public IDataResult<List<Firm>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<Firm>>(_dal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<Firm>>(e.Message);
            }
        }

        public IResult Delete(Firm entity)
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

        public IResult Update(Firm entity)
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
        #endregion

        #region Async
        public async Task<IResult> UpdateAsync(Firm entity)
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

        public async Task<IResult> AddAsync(Firm entity)
        {
            try
            {
                await _dal.AddAsync(entity);
                await _unitOfWork.CompleteAsync();

                return new SuccessDataResult<Firm>(entity, BasicCrudOperationMessages.SUCCESS_ADD);
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
                Firm entity = await _dal.FindByIdAsync(Id);
                if (entity == null)
                {
                    return new FailDataResult<Firm>($"{BasicCrudOperationMessages.NOT_FOUND_ENTİTY} :That belonging to {Id} any entity.");
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

        public async Task<IDataResult<Firm>> FindByIdAsync(int Id)
        {
            try
            {
                Firm entity = await _dal.FindByIdAsync(Id);
                if (entity == null)
                {
                    return new FailDataResult<Firm>($"{BasicCrudOperationMessages.NOT_FOUND_ENTİTY} :That belonging to {Id} any entity.");
                }
                return new SuccessDataResult<Firm>(entity, $"{BasicCrudOperationMessages.SUCCESS_GET_ID}");
            }
            catch (Exception ex)
            {
                return new FailDataResult<Firm>($"{BasicCrudOperationMessages.FIND_BY_ID_ERROR} :Exception : {ex.Message}");
            }
        }

        public async Task<IDataResult<IList<Firm>>> GetEntityValuesAsync()
        {
            try
            {
                //filling entity list
                IEnumerable<Firm> entities = await _dal.ListAsync();
                return new SuccessDataResult<IList<Firm>>(entities.ToList(), $"{BasicCrudOperationMessages.SUCCESS_GET_LİST}");
            }
            catch (Exception ex)
            {

                return new FailDataResult<IList<Firm>>($"There is an error.When it finding the list : {ex.Message}");
            }
        }

        #endregion

        #region Unneccessary
        //public override IResult AddByVirtualMethod(Firm entity)
        // {
        // try
        //{
        //FluentValidationTool.Validate(new FirmValidator(), entity);
        // _dal.Add(entity);

        //        _unitOfWork.Complete();

        //        return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
        //    }

        //    catch (Exception e)
        //    {
        //        return new FailResult($"{BasicCrudOperationMessages.FAIL_ADD} : {e.Message}");
        //    }
        //}


        //[ValidationAspect(typeof(FirmValidator), Priority = 1)]
        //public override IResult UpdateByVirtualMethod(Firm entity)
        //{
        //    try
        //    {
        //        FluentValidationTool.Validate(new FirmValidator(), entity);
        //        _dal.Update(entity);

        //        _unitOfWork.Complete();

        //        return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
        //    }

        //    catch (Exception e)
        //    {
        //        return new FailResult($"{BasicCrudOperationMessages.FAIL_UPDATE} :");
        //    }
        //}

        #endregion

    }

}

