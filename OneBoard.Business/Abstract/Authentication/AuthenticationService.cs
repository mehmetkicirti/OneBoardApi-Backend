using Microsoft.Extensions.Options;
using OneBoard.Business.ValidationRules._FluentValidation;
using OneBoard.Business.ValidationRules.ForDTOValidation;
using OneBoard.Core.Aspects.Autofac.Logging;
using OneBoard.Core.Aspects.Autofac.Validation;
using OneBoard.Core.Business;
using OneBoard.Core.CrossCuttingCornces.Logging.Log4Net.Loggers;
using OneBoard.Core.DataAccess;
using OneBoard.Core.Helper;
using OneBoard.Core.Utilities;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Results.Concerete.Data;
using OneBoard.Core.Utilities.Security.Token;
using OneBoard.Entities.Concrete;
using System;
using System.Threading.Tasks;

namespace OneBoard.Business.Abstract.Authentication
{
    [LogAspect(typeof(DatabaseLogger))]
    
    
    public class AuthenticationService : BaseAuthenticationService, IAuthenticationService<AccessToken>
    {
        private readonly TokenOptions _tokenOptions;
        public AuthenticationService(IUserService _iUserService, ITokenHandler _tokenHandler, IUnitOfWork _unitOfWork, IOptions<TokenOptions> tokenOptions) : base(_iUserService,_tokenHandler,_unitOfWork)
        {
            this._tokenOptions = tokenOptions.Value;
        }

        [ValidationAspect(typeof(LoginDTOValidator))]
        public async Task<IDataResult<AccessToken>> CreateAccessToken(string LoginName, string password)
        {
            string EncryptPassword = EncryptionPassword.Encrypt(password);

            IDataResult<User> user = await _userService.FindLoginNameAndPassword(LoginName, EncryptPassword);

            if (user.Success)
            {
                AccessToken accessToken = _tokenHandler.CreateAccessToken(user.Data);
                user.Data.RefreshToken = accessToken.RefreshToken;
                user.Data.RefreshTokenEndDate = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);
                await _unitOfWork.CompleteAsync();
                //await _userService.SaveRefreshToken(user.Data.ID, accessToken.RefreshToken);
                return new SuccessDataResult<AccessToken>(accessToken, BasicCrudOperationMessages.CREATE_TOKEN);
            }
            else
            {
                return new FailDataResult<AccessToken>(BasicCrudOperationMessages.FAIL_CREATE_TOKEN + $" \n {user.Message}");
            }

        }

        public async Task<IDataResult<AccessToken>> CreateAccessTokenWithRefreshToken(string refreshToken)
        {
            IDataResult<User> user = await _userService.GetUserWithRefreshToken(refreshToken);
            if (user.Success)
            {
                //Gecerliligi var
                if (user.Data.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = _tokenHandler.CreateAccessToken(user.Data);
                    user.Data.RefreshToken = accessToken.RefreshToken;
                    await _unitOfWork.CompleteAsync();
                    //await _userService.SaveRefreshToken(user.Data.ID, accessToken.RefreshToken);
                    return new SuccessDataResult<AccessToken>(accessToken, BasicCrudOperationMessages.CREATE_TOKEN);
                }
                else
                    return new FailDataResult<AccessToken>(BasicCrudOperationMessages.ACCESS_TOKEN_ENOUGH_TİME_NOT);
            }
            else
                return new FailDataResult<AccessToken>(
                    BasicCrudOperationMessages.HAVE_NOT_USER);
        }

        public async Task<IDataResult<AccessToken>> RevokeRefreshToken(string refreshToken)
        {
            IDataResult<User> user = await _userService.GetUserWithRefreshToken(refreshToken);

            if (user.Success)
            {
                await _userService.RemoveRefreshToken(user.Data);
                user.Data.LastLogin = DateTime.UtcNow;

                return new SuccessDataResult<AccessToken>(new AccessToken(), BasicCrudOperationMessages.USER_EXIT);
            }
            else
                return new FailDataResult<AccessToken>(BasicCrudOperationMessages.TOKEN_NOT_FOUND);
        }
    }
}
