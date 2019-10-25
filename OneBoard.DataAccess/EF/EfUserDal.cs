using Microsoft.Extensions.Options;
using OneBoard.Core.DataAccess;
using OneBoard.Core.DataAccess.EntityFramework;
using OneBoard.Core.Helper;
using OneBoard.Core.Utilities.Security.Token;
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
    public class EfUserDal : EfEntityRepositoryBase<User, DatabaseContext>, IUserDal
    {
        private readonly TokenOptions tokenOptions;
        //private readonly IUnitOfWork _unitofwork;
        public EfUserDal(DatabaseContext _context, IOptions<TokenOptions> tokenOptions) : base(context: _context)
        {
            this.tokenOptions = tokenOptions.Value;
            //this._unitofwork = unitOfWork;
        }

        public async Task AddUserAsync(User user)
        {
            user.LastLogin = DateTime.UtcNow;
            await _context.AddAsync(user);
        }

        public async Task<User> FindByLoginNameAndPassword(string LoginName, string password)
        {
            //string encryptPassword = EncryptionPassword.Decrypt(password);

            Task<User> task = Task.Run(() =>
                 _context.Users.Where(u => u.LoginName == LoginName && u.Password == password).FirstOrDefault()
            );

            return await task;
        }

        public async Task<User> GetUserByRefreshToken(string refreshToken)
        {
            Task<User> task = Task.Run(() =>
                 _context.Users.Where(u => u.RefreshToken == refreshToken).FirstOrDefault()
            );

            return await task;
        }

        public async Task<int> GetUsersCount()
        {
            Task<int> task = Task.Run(() =>
                _context.Users.Count()
            );
            return await task;
        }

        public async Task RemoveRefreshToken(User user)
        {
            await Task.Run(() =>
            {
                User newUser = this.Find(user.ID);
                newUser.RefreshToken = null;
                newUser.RefreshTokenEndDate = null;
                return newUser;
            });
        }

        public async Task SaveRefreshToken(int userId, string refreshToken)
        {

            User newUser = await this.FindByIdAsync(userId);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration);
            await Task.CompletedTask;
        }
    }
}
