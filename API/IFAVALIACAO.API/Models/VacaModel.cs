using System;
using System.ComponentModel.DataAnnotations;

namespace IFAVALIACAO.API.Models
{
    public class VacaModel : EntityModel
    {

        public Guid? FazendaId { get; set; }
        public string FazendaInscricaoEstadual { get; set; }
        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Nome { get; set; }
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Numero deve ser maior que zero.")]
        public int Numero { get; set; }
        public Guid? VacaMaeId { get; set; }
        public int? NumeroVacaMae { get; set; }
        public string NomePai { get; set; }
        public int NumeroPai { get; set; }
        public string Raca { get; set; }
        public DateTime DataNascimento { get; set; }
        public string GrauSanguineo { get; set; }
        public int OrdemParto { get; set; }
        public int Ipp { get; set; }

        public FazendaModel Fazenda { get; set; }
        public VacaModel Vaca { get; set; }
    }
}