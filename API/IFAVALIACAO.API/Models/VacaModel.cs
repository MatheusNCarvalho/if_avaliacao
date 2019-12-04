using System;

namespace IFAVALIACAO.API.Models
{
    public class VacaModel : EntityModel
    {
        public Guid FazendaId { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public Guid? VacaMae { get; set; }
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