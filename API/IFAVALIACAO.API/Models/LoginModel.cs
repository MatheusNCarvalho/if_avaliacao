using System.ComponentModel.DataAnnotations;

namespace IFAVALIACAO.API.Models
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Required(ErrorMessage = "Email é obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatorio")]
        public string Password { get; set; }
    }
}