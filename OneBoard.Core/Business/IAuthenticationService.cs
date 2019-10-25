using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Security.Token;
using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Core.Business
{
    public interface IAuthenticationService<TEntity>
        where TEntity : class, IEntity, new()
    {
        Task<IDataResult<AccessToken>> CreateAccessToken(string LoginName, string password);
        Task<IDataResult<AccessToken>> CreateAccessTokenWithRefreshToken(string refreshToken);
        //to exit user using
        Task<IDataResult<AccessToken>> RevokeRefreshToken(string refreshToken);

    }
}
