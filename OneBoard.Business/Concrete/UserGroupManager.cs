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
    public class UserGroupManager : IUserGroupService
    {
        private readonly IUserGroupDal _iUserGroupDal;
        public UserGroupManager(IUserGroupDal iUserGroupDal)
        {
            _iUserGroupDal = iUserGroupDal;
        }
        public IResult Add(UserGroup entity)
        {
            try
            {
                _iUserGroupDal.Add(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(UserGroup entity)
        {
            try
            {
                _iUserGroupDal.Delete(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }
            catch (Exception e)
            {

                return new FailResult(e.Message);
            }
        }

        public IDataResult<UserGroup> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<UserGroup>(_iUserGroupDal.Get(d => d.ID == Id), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {

                return new FailDataResult<UserGroup>(_iUserGroupDal.Get(d => d.ID == Id), e.Message);
            }
        }

        public IDataResult<IQueryable<UserGroup>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<UserGroup>>(_iUserGroupDal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<IQueryable<UserGroup>>(_iUserGroupDal.GetListByQueryable(), e.Message);
            }
        }

        public IDataResult<List<UserGroup>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<UserGroup>>(_iUserGroupDal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<List<UserGroup>>(_iUserGroupDal.GetList().ToList(), e.Message);
            }
        }

        public IResult Update(UserGroup entity)
        {
            try
            {
                _iUserGroupDal.Update(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }
    }
}
