﻿namespace IFAvaliacao.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
