using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Security.Token
{
    public class TokenOptions:IDTO
    {
        //Who will use
        public string Audience { get; set; }
        //Who will publish
        public string Issuer { get; set; }
        //When it is expiration
        public int AccessTokenExpiration{ get; set; }
        //When it is refresh token
        public int RefreshTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
