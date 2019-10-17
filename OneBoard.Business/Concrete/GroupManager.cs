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
        public IResult Add(Group entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Group> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IQueryable<Group>> GetEntityQueryable()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Group>> GetEntityValues()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
