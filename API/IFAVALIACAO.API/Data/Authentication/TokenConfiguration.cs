﻿using IFAVALIACAO.API.Domain.Interfaces.Authentication;

namespace IFAVALIACAO.API.Data.Authentication
{
    public class TokenConfiguration : ITokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Days { get; set; }
    }
}