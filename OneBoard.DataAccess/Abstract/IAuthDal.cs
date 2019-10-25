using OneBoard.Core.DataAccess;
using OneBoard.Core.Utilities.Security.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.DataAccess.Abstract
{
    public interface IAuthDal: IEntityRepository<AccessToken>
    {
    }
}
