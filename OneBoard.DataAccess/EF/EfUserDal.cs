using OneBoard.Core.DataAccess.EntityFramework;
using OneBoard.DataAccess.Abstract;
using OneBoard.DataAccess.EF._DatabaseContext;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.DataAccess.EF
{
    public class EfUserDal : EfEntityRepositoryBase<User, DatabaseContext> ,IUserDal
    {
        public EfUserDal(DatabaseContext _context):base(context:_context)
        {
        }

        public async Task<User> FindByLoginNameAndPassword(string LoginName, string password)
        {
            string hashPassword = SecurityAlgorithms.HmacSha256Signature;
            
            Task<User> t= Task.Run(() => 
                _context.Users.Where(u => u.LoginName == LoginName && u.Password == hashPassword).FirstOrDefault()
            );

            return await t;
        }

        public async Task<User> GetUserByRefreshToken(string refreshToken)
        {
            Task<User> t= Task.Run(() =>
                _context.Users.Where(u => u.RefreshToken == refreshToken).FirstOrDefault()
            );

            return await t;
        }

        public async Task<int> GetUsersCount()
        {
            Task<int> t = Task.Run(() =>
                _context.Users.Count()
            );
            return await t;
        }

        public Task RemoveRefreshToken(User user)
        {
            Task t = Task.Run(() => _context.Users.);
        }

        public Task SaveRefreshToken(int userId, string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
