using OneBoard.Business.Abstract;
using OneBoard.Business.Constants;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Results.Concerete.Data;
using OneBoard.Core.Utilities.Results.Concerete.Result;
using OneBoard.DataAccess.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneBoard.Business.Concrete
{
    public class FirmManager : IFirmService
    {

        private readonly IFirmDal _dal;

        public FirmManager(IFirmDal dal)
        {
            this._dal = dal;
        }
        public IResult Add(Firm firm)
        {
            try
            {
                _dal.Add(firm);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }

            catch(Exception e)
            {
                return new FailResult(e.Message);
            }
           
        }

        public IResult Delete(Firm firm)
        {
            try
            {
                _dal.Delete(firm);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }

            catch(Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IDataResult<Firm> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Firm>(_dal.Get(f => f.ID == Id), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }

            catch(Exception e)
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


        public IResult Update(Firm firm)
        {
            try
            {
                _dal.Update(firm);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }
    }
}
