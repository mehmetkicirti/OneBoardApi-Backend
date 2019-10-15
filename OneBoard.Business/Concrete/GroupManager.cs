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
            _dal.Add(group);
            return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
        }

        public IResult Delete(Group group)
        {
            _dal.Delete(group);
            return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
        }

        public IDataResult<List<Group>> GetGroups()
        {

            return new SuccessDataResult<List<Group>>(_dal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
        }

        public IResult Update(Group group)
        {
            _dal.Update(group);
            return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
        }
    }
}
