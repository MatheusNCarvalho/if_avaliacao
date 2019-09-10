using SQLite;
using System;

namespace IFAvaliacao.Domain.Entities
{
    public class Vaca : EntityBase
    {
        public string FazendaId { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string NomePai { get; set; }
        public int NumeroPai { get; set; }
        public string NomeMae { get; set; }
        public int NumeroMae { get; set; }
        public string Raca { get; set; }
        public string GrauSanguinio { get; set; }
        public DateTime? DataNascimento { get; set; }
        /// <summary>
        /// Ordem de parto: (quantos partos a vaca teve ao longo da vida)
        /// </summary>
        public int OrdemParto { get; set; }
        /// <summary>
        /// IPP (idade ao primeiro parto):
        /// </summary>
        public int Ipp { get; set; }

        [Ignore]
        public Fazenda Fazenda { get; set; }
    }
}
