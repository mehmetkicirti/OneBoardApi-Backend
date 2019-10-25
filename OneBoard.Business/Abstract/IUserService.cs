using OneBoard.Core.Business;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Business.Abstract
{
   public interface IUserService:IService<User>
   {
        Task<IResult> AddUser(User user);
        Task<IDataResult<int>> GetUserCount();
        Task<IDataResult<User>> FindLoginNameAndPassword(string LoginName, string Password);
        Task<IResult> SaveRefreshToken(int UserId, string refreshToken);
        Task<IDataResult<User>> GetUserWithRefreshToken(string refreshToken);
        Task<IResult> RemoveRefreshToken(User user);

   }
}
