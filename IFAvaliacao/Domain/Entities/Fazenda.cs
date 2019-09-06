

namespace IFAvaliacao.Domain.Entities
{
    public class Fazenda : EntityBase
    {

        //public Fazenda(string escricaoEstadual, string nome, string nomeFazenda, string cep, string rua, string bairro, string cidade, string estado)
        //{
        //    EscricaoEstadual = escricaoEstadual;
        //    Nome = nome;
        //    NomeFazenda = nomeFazenda;
        //    Cep = cep;
        //    Rua = rua;
        //    Bairro = bairro;
        //    Cidade = cidade;
        //    Estado = estado;
        //}

        public string EscricaoEstadual { get; set; }
        public string Nome { get; set; }
        public string NomeFazenda { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public string CidadeEstado => $"{Cidade}/{Estado}";



    }
}
