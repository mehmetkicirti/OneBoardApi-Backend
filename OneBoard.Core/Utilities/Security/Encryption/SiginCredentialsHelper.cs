using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Security.Encryption
{
    public class SiginCredentialsHelper
    {
        public static SigningCredentials CreateSigingCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, algorithm: SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
