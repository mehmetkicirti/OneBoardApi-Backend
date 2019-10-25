using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using OneBoard.Core.Utilities.Security.Encryption;
using OneBoard.Entities.Abstract;
using OneBoard.Entities.Concrete;

namespace OneBoard.Core.Utilities.Security.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenOptions _options;
        //DI IOption icin deki TokenOptions is filling from using each class
        public TokenHandler(IOptions<TokenOptions> tokenOptions)
        {
            _options = tokenOptions.Value;
        }
        public AccessToken CreateAccessToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_options.AccessTokenExpiration);
            var securityKey = SignHandler.GetSecurityKey(_options.SecurityKey);
            var encryptedKey = SiginCredentialsHelper.CreateSigingCredentials(securityKey);

            #region SecurityToken
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                   issuer: _options.Issuer,
                   audience: _options.Audience,
                   expires: accessTokenExpiration,
                   notBefore: DateTime.Now, //Suan olustukdan 5 dk sonra gecerli olsun tarzında.Geçerli olucagı tarih.
                   signingCredentials: encryptedKey,
                   claims: GetClaims(user)
                   );

            #endregion
            #region TokenWriteCreating
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            #endregion
            #region GetAccesToken Object

            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            accessToken.ExpirationEnd = accessTokenExpiration;
            accessToken.RefreshToken = CreateRefreshToken();

            #endregion
            return accessToken;
        }

        public void RevokeRefreshToken(User user)
        {
            //adjust to Null refresh token
            user.RefreshToken = null;
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
            new Claim("UserType", user.UserType.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("LoginName", user.LoginName.ToString()),
            new Claim("LastLogin", user.LastLogin.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            return claims;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using (var randomGenerator = RandomNumberGenerator.Create())
            {
                randomGenerator.GetBytes(numberByte);

                return Convert.ToBase64String(numberByte);
            }
            //RETURN Guid.NewGuid(); İNSTEAD OF
        }
    }
}
