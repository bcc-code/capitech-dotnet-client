using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Access
{
    public class LoginResponse
    {
        public Guid AccessToken { get; set; }

        public DateTimeOffset AccessTokenExpires { get; set; } 

        public Guid RefreshToken { get; set; }

        public DateTimeOffset RefreshTokenExpires { get; set; }
    }
}
