using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        //Çıkıs yaptıkdan sonra localstoragedan silicez.Null yapıcaz.
        void RevokeRefreshToken(User user);
    }
}
