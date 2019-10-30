using System.ComponentModel.DataAnnotations;

namespace IFAVALIACAO.API.Domain.Entites
{
    public class User : Entity
    {

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }


        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Name { get; private set; }
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Required(ErrorMessage = "Email é obrigatorio")]
        public string Email { get; private set; }
        [Required(ErrorMessage = "Senha é obrigatorio")]
        public string Password { get; private set; }
    }
}