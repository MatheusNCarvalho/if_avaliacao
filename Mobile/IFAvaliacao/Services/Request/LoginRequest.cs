using System;
using System.Collections.Generic;
using System.Text;

namespace IFAvaliacao.Services.Request
{
    public class LoginRequest
    {
        public LoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
