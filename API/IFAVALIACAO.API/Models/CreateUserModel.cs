using System.ComponentModel.DataAnnotations;

namespace IFAVALIACAO.API.Models
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Required(ErrorMessage = "Email é obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatorio")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não correspondem.")]
        public string PasswordConfirmation { get; set; }
    }
}