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
    public class GroupManager : IGroupService
    {

        public IGroupDal _dal;

        public GroupManager(IGroupDal dal)
        {
            this._dal = dal;
        }
        public IResult Add(Group group)
        {

            try
            {
                _dal.Add(group);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(Group group)
        {
            try
            {
                _dal.Delete(group);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }

            catch(Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IDataResult<Group> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Group>(_dal.Get(filter: f => f.ID == Id),BasicCrudOperationMessages.SUCCESS_ADD);
            }

            catch(Exception e)
            {

                return new FailDataResult<Group>(e.Message);
            }
        }

        public IDataResult<IQueryable<Group>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<Group>>(_dal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);

            }

            catch (Exception e)
            {
                return new FailDataResult<IQueryable<Group>>(e.Message);
            }
        }

        public IDataResult<List<Group>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<Group>>(_dal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);

            }

            catch (Exception e)
            {
                return new FailDataResult<List<Group>>(e.Message);
            }
        }

  

        public IResult Update(Group group)
        {
            try
            {
                _dal.Update(group);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }

            catch(Exception e)
            {
                return new FailResult(e.Message);
            }
            
        }
    }
}
