using System;

namespace IFAVALIACAO.API.Domain.Entites
{
    public class Vaca : Entity
    {
        public Guid FazendaId { get; private set; }
        public string Nome { get; private set; }
        public int Numero { get; private set; }
        public string NomePai { get; private set; }
        public int NumeroPai { get; private set; }
        public Guid? IdVacaMae { get; private set; }
        public string Raca { get; private set; }
        public string GrauSanguinio { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        /// <summary>
        /// Ordem de parto: (quantos partos a vaca teve ao longo da vida)
        /// </summary>
        public int OrdemParto { get; private set; }
        /// <summary>
        /// IPP (idade ao primeiro parto):
        /// </summary>
        public int Ipp { get; private set; }
     
        public Fazenda Fazenda { get; private set; }
    
        public Vaca VacaMae { get; private set; }
    }
}