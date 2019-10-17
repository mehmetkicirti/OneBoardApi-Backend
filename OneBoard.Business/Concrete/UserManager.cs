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

        public IUserDal _userDal;

        public UserManager(IUserDal dal)
        {
            _userDal = dal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
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
                return new FailDataResult<User>(_userDal.Get(u => u.ID == userId), e.Message);
            }
        }

        public IDataResult<List<User>> GetEntityValues()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList(),BasicCrudOperationMessages.SUCCESS_GET_LİST);
           
        }

        public IDataResult<IQueryable<User>> GetEntityQueryable()
        {
            return new SuccessDataResult<IQueryable<User>>(_userDal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);


        }
    }
}
