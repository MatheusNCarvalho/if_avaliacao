using System.ComponentModel.DataAnnotations;

namespace IFAVALIACAO.API.Models
{
    public class FazendaModel : EntityModel
    {
        [Required(ErrorMessage = "Nome do proprietario é obrigatorio")]
        public string NomeProprietario { get; set; }
        [Required(ErrorMessage = "Nome da fazenda é obrigatorio")]
        public string NomeFazenda { get; set; }
        [Required(ErrorMessage = "Inscrição Estadual é obrigatorio")]
        public string InscricaoEstadual { get; set; }
        [Required(ErrorMessage = "Cep é obrigatorio")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Endereço é obrigatorio")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Cidade é obrigatorio")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Estado é obrigatorio")]
        public string Estado { get; set; }

    }
}
