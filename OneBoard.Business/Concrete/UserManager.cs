using OneBoard.Business.Abstract;
using OneBoard.Core.Business.EFBaseService;
using OneBoard.Core.DataAccess;
using OneBoard.Core.Helper;
using OneBoard.Core.Utilities;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Results.Concerete.Data;
using OneBoard.Core.Utilities.Results.Concerete.Result;
using OneBoard.DataAccess.Abstract;
using OneBoard.DataAccess.EF._DatabaseContext;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Business.Concrete
{
    public class UserManager : EfBaseService<IUserDal, User>, IUserService
    {
        //private readonly DatabaseContext _context;
        public UserManager(IUserDal _dal, IUnitOfWork _unitOfWork) : base(_dal, _unitOfWork)
        {
            //_context = context;
        }

        public async Task<IResult> AddUser(User user)
        {
            try
            {
                await _dal.AddUserAsync(user);
                user.UserType = (int)UserTypes.NormalUser;
                user.Password = EncryptionPassword.Encrypt(user.Password);
                await _unitOfWork.CompleteAsync();
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception ex)
            {
                return new FailResult($"{BasicCrudOperationMessages.FAIL_ADD} : \n Error Exception Message : {ex.Message}");
            }
        }

        public async Task<IDataResult<User>> FindLoginNameAndPassword(string LoginName, string Password)
        {
            try
            {
                User user = await _dal.FindByLoginNameAndPassword(LoginName, Password);

                if (user == null)
                    return new FailDataResult<User>(user, BasicCrudOperationMessages.NOT_FOUND_ENTİTY);

                return new SuccessDataResult<User>(user);
            }
            catch (Exception ex)
            {

                return new FailDataResult<User>($"{BasicCrudOperationMessages.FIND_BY_NAME_AND_PASSWORD} \n Error Message : {ex.Message}");
            }
        }

        public async Task<IDataResult<int>> GetUserCount()
        {
            try
            {
                int count = await _dal.GetUsersCount();
                return new SuccessDataResult<int>(count, $"User Count : {count}");
            }
            catch (Exception ex)
            {

                return new FailDataResult<int>(ex.Message);
            }
        }

        public async Task<IDataResult<User>> GetUserWithRefreshToken(string refreshToken)
        {
            try
            {
                User user = await _dal.GetUserByRefreshToken(refreshToken);

                if (user == null)
                    return new FailDataResult<User>(user, BasicCrudOperationMessages.NOT_FOUND_ENTİTY);

                return new SuccessDataResult<User>(user);
            }
            catch (Exception ex)
            {

                return new FailDataResult<User>($"{BasicCrudOperationMessages.GET_USER_REFRESH_TOKEN} \n Error Message : {ex.Message}");
            }
        }

        public async Task<IResult> RemoveRefreshToken(User user)
        {
            try
            {
                await _dal.RemoveRefreshToken(user);
                await _unitOfWork.CompleteAsync();

                return new SuccessResult(BasicCrudOperationMessages.REMOVE_REFRESH_TOKEN);
            }
            catch (Exception ex)
            {
                //in here will be logging
                return new FailResult(ex.Message);
            }
        }

        public async Task<IResult> SaveRefreshToken(int UserId, string refreshToken)
        {
            try
            {
                await _dal.SaveRefreshToken(UserId, refreshToken);
                await _unitOfWork.CompleteAsync();
                return new SuccessResult(BasicCrudOperationMessages.SAVE_REFRESH_TOKEN);
            }
            catch (Exception ex)
            {
                //in here will be logging
                return new FailResult(ex.Message);
            }
        }
    }
}
