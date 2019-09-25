using System;

namespace IFAvaliacao.Domain.Entities
{
    public class AvaliacaoVaca : EntityBase
    {
        public AvaliacaoVaca() { }

        public AvaliacaoVaca(int nameCow, decimal bodyWight)
        {
            NameCow = nameCow;
            BodyWight = bodyWight;
        }
        public AvaliacaoVaca(int nameCow, decimal bodyWight, int angulosiodade, int profundidadeCorporal, int forcaLeiteira,
                             int alturaGarupaHipometro, int comprimentoCorpo, int anguloCarupa, int larguraIleo,
                             int larguraIsquio, int anguloCasco, int jarreteLateral, int jarreteTras, int ubereFirmeza,
                             int uberePosterior, int alturaUbere, int ligamentoCentral, int posicaoTetos, DateTime dataHoraIinicio)
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
    }
}