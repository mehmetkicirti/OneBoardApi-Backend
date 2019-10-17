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
    public class UserManager : IUserService
    {

        private readonly IUserDal _userDal;

        public UserManager(IUserDal dal)
        {
            _userDal = dal;
        }
        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IDataResult<User> GetById(int userId)
        {
            //return new  _userDal.Get(u => u.ID == userId);
            try
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.ID == userId), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {
                return new FailDataResult<User>(e.Message);
            }
        }

        public IDataResult<List<User>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<User>>(e.Message);
            }


        }

        public IDataResult<IQueryable<User>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<User>>(_userDal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            
            catch(Exception e)
            {
                return new FailDataResult<IQueryable<User>>(e.Message);
            }
        }

        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }


        }
    }
}
