using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneBoard.Business.Abstract
{
   public interface IUserService
   {
        IResult Add(User user);

        IResult Update(User user);

        IResult Delete(User user);

        IDataResult<List<User>> GetUsers();

        IDataResult<IQueryable<User>> GetUsersQueryable();
   }
}
