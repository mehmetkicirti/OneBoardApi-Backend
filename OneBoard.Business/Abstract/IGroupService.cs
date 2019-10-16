using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.Abstract
{
    public interface IGroupService
    {
        IResult Add(Group group);

        IResult Delete(Group group);

        IResult Update(Group group);

        IDataResult<List<Group>> GetGroups();
    }
}
