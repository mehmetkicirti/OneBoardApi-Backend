using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Security.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpirationEnd { get; set; }
        public string RefreshToken { get; set; }
    }
}
