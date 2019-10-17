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
    public class UserFirmManager : IUserFirmService
    {
        private readonly IUserFirmDal _iUserFirmDal;

        public UserFirmManager(IUserFirmDal iUserFirmDal)
        {
            _iUserFirmDal = iUserFirmDal;
        }
        public IResult Add(UserFirm entity)
        {

            try
            {
                _iUserFirmDal.Add(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(UserFirm entity)
        {
            try
            {
                _iUserFirmDal.Delete(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }
            catch (Exception e)
            {

                return new FailResult(e.Message);
            }
        }

        public IDataResult<UserFirm> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<UserFirm>(_iUserFirmDal.Get(d => d.Id == Id), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {

                return new FailDataResult<UserFirm>(_iUserFirmDal.Get(d => d.Id == Id), e.Message);
            }
        }

        public IDataResult<IQueryable<UserFirm>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<UserFirm>>(_iUserFirmDal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<IQueryable<UserFirm>>(_iUserFirmDal.GetListByQueryable(), e.Message);
            }
        }

        public IDataResult<List<UserFirm>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<UserFirm>>(_iUserFirmDal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<List<UserFirm>>(_iUserFirmDal.GetList().ToList(), e.Message);
            }
        }

        public IResult Update(UserFirm entity)
        {
            try
            {
                _iUserFirmDal.Update(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);

            }
        }
    }
}
