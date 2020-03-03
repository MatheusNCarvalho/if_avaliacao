using IFAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFAvaliacao.Services.Response
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Token { get; set; }
        public Usuario User { get; set; }
    }
}
