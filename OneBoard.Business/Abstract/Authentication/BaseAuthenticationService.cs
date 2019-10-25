using OneBoard.Core.DataAccess;
using OneBoard.Core.Utilities.Security.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.Abstract.Authentication
{
    public class BaseAuthenticationService
    {
        protected readonly IUserService _userService;
        protected readonly ITokenHandler _tokenHandler;
        protected readonly IUnitOfWork _unitOfWork;
        public BaseAuthenticationService(IUserService userService, ITokenHandler tokenHandler,IUnitOfWork unitOfWork)
        {
            this._tokenHandler = tokenHandler;
            this._userService = userService;
            this._unitOfWork = unitOfWork;
        }
    }
}
