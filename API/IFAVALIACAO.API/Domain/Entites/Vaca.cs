using System;
using System.Collections.Generic;

namespace IFAVALIACAO.API.Domain.Entites
{
    public class Vaca : Entity
    {
        protected  Vaca() { }

        public Vaca(
                    string nome, 
                    int numero, 
                    string nomePai, 
                    int? numeroPai, 
                    string raca, 
                    string grauSanguinio, 
                    DateTime? dataNascimento, 
                    int? ordemParto, 
                    int? ipp, 
                    Fazenda fazenda, 
                    Vaca vacaMae,
                    Guid? id)
        {

            if (id.HasValue)
            {
                Id = id.Value;
            }
            Nome = nome;
            Numero = numero;
            NomePai = nomePai;
            NumeroPai = numeroPai;
            Raca = raca;
            GrauSanguinio = grauSanguinio;
            DataNascimento = dataNascimento;
            OrdemParto = ordemParto;
            Ipp = ipp;
            Fazenda = fazenda;
            VacaMae = vacaMae;
        }
       
        public string Nome { get; private set; }
        public int Numero { get; private set; }
        public string NomePai { get; private set; }
        public int? NumeroPai { get; private set; }
        public Guid? VacaMaeId { get; private set; }
        public string Raca { get; private set; }
        public string GrauSanguinio { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        /// <summary>
        /// Ordem de parto: (quantos partos a vaca teve ao longo da vida)
        /// </summary>
        public int? OrdemParto { get; private set; }
        /// <summary>
        /// IPP (idade ao primeiro parto):
        /// </summary>
        public int? Ipp { get; private set; }
     
        public Fazenda Fazenda { get; private set; }
    
        public Vaca VacaMae { get; private set; }

        public IList<Vaca> VacasMaes { get; private set; }

        public void SetName(string nome)
        {
            Nome = nome;
        }

        public void SetNumero(int numero)
        {
            Numero = numero;
        }

        public void SetNomePai(string nomePai)
        {
            NomePai = nomePai;
        }

        public void SetNumeroPai(int? numeroPai)
        {
            NumeroPai = numeroPai;
        }

        public void SetRaca(string raca)
        {
            Raca = raca;
        }

        public void SetGrauSanguinio(string grauSanguinio)
        {
            GrauSanguinio = grauSanguinio;
        }

        public void SetDataNascimento(DateTime? dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        public void SetOrdemParto(int? ordemParto)
        {
            OrdemParto = ordemParto;
        }

        public void SetIpp(int? ipp)
        {
            Ipp = ipp;
        }

        public void SetFazenda(Fazenda fazenda)
        {
            Fazenda = fazenda;
        }

        public void SetVacaMae(Vaca vacaMae)
        {
            VacaMae = vacaMae;
        }
    }
}