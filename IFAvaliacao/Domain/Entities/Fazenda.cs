

namespace IFAvaliacao.Domain.Entities
{
    public class Fazenda : EntityBase
    {

        public string InscricaoEstadual { get; set; }
        public string Nome { get; set; }
        public string NomeFazenda { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public string CidadeEstado => $"{Cidade}/{Estado}";



    }
}
