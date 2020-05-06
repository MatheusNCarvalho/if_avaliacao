using System;

namespace IFAvaliacao.Domain.Entities
{
    public class AvaliacaoVaca : EntityBase
    {
        public AvaliacaoVaca() { }

        public AvaliacaoVaca(int nameCow, decimal bodyWight)
        {
            Id = null;
            NameCow = nameCow;
            BodyWight = bodyWight;
        }
        public AvaliacaoVaca(int nameCow, decimal bodyWight, int angulosiodade, int profundidadeCorporal, int forcaLeiteira,
                             int alturaGarupaHipometro, int comprimentoCorpo, int anguloCarupa, int larguraIleo,
                             int larguraIsquio, int anguloCasco, int jarreteLateral, int jarreteTras, int ubereFirmeza,
                             int uberePosterior, int alturaUbere, int ligamentoCentral, int posicaoTetos, DateTime dataHoraIinicio,
                             decimal comprimentoTeto1, decimal comprimentoTeto2, decimal comprimentoTeto3, decimal comprimentoTeto4,
                             decimal diametroTeto1, decimal diametroTeto2, decimal diametroTeto3, decimal diametroTeto4)
        {
            NameCow = nameCow;
            BodyWight = bodyWight;
            Angulosiodade = angulosiodade;
            ProfundidadeCorporal = profundidadeCorporal;
            ForcaLeiteira = forcaLeiteira;
            AlturaGarupaHipometro = alturaGarupaHipometro;
            ComprimentoCorpo = comprimentoCorpo;
            AnguloCarupa = anguloCarupa;
            LarguraIleo = larguraIleo;
            LarguraIsquio = larguraIsquio;
            AnguloCasco = anguloCasco;
            JarreteLateral = jarreteLateral;
            JarreteTras = jarreteTras;
            UbereFirmeza = ubereFirmeza;
            UberePosterior = uberePosterior;
            AlturaUbere = alturaUbere;
            LigamentoCentral = ligamentoCentral;
            PosicaoTetos = posicaoTetos;
            DataHoraInicio = dataHoraIinicio;
            ComprimentoTeto1 = comprimentoTeto1;
            ComprimentoTeto2 = comprimentoTeto2;
            ComprimentoTeto3 = comprimentoTeto3;
            ComprimentoTeto4 = comprimentoTeto4;
            DiametroTeto1 = diametroTeto1;
            DiametroTeto2 = diametroTeto2;
            DiametroTeto3 = diametroTeto3;
            DiametroTeto4 = diametroTeto4;
        }

        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public int NameCow { get; set; }
        public decimal BodyWight { get; set; }

        public int Angulosiodade { get; set; }

        public int ProfundidadeCorporal { get; set; }

        public int ForcaLeiteira { get; set; }

        public int AlturaGarupaHipometro { get; set; }

        public int ComprimentoCorpo { get; set; }

        public int AnguloCarupa { get; set; }

        public int LarguraIleo { get; set; }

        public int LarguraIsquio { get; set; }

        public int AnguloCasco { get; set; }

        public int JarreteLateral { get; set; }

        public int JarreteTras { get; set; }

        public int UbereFirmeza { get; set; }
        public int UberePosterior { get; set; }

        public int AlturaUbere { get; set; }

        public int LigamentoCentral { get; set; }

        public int PosicaoTetos { get; set; }
        public decimal ComprimentoTeto1 { get; set; }

        public decimal ComprimentoTeto2 { get; set; }

        public decimal ComprimentoTeto3 { get; set; }

        public decimal ComprimentoTeto4 { get; set; }

        public decimal DiametroTeto1 { get; set; }

        public decimal DiametroTeto2 { get; set; }

        public decimal DiametroTeto3 { get; set; }

        public decimal DiametroTeto4 { get; set; }
    }
}