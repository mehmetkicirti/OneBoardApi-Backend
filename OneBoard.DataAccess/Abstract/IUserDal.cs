using OneBoard.Core.DataAccess;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        Task AddUserAsync(User user);
        Task<User> FindByLoginNameAndPassword(string LoginName, string password);
        Task SaveRefreshToken(int userId, string refreshToken);
        Task<User> GetUserByRefreshToken(string refreshToken);
        Task RemoveRefreshToken(User user);
        Task<int> GetUsersCount();

    }
}
