using System;

namespace IFAVALIACAO.API.Models
{
    public class AvaliacaoModel : EntityModel
    {
        public DateTime DataHoraInicio { get;  set; }
        public DateTime DataHoraFim { get;  set; }
        public int NameCow { get;  set; }
        public decimal BodyWight { get;  set; }

        public int Angulosiodade { get;  set; }

        public int ProfundidadeCorporal { get;  set; }

        public int ForcaLeiteira { get;  set; }

        public int AlturaGarupaHipometro { get;  set; }

        public int ComprimentoCorpo { get;  set; }

        public int AnguloCarupa { get;  set; }

        public int LarguraIleo { get;  set; }

        public int LarguraIsquio { get;  set; }

        public int AnguloCasco { get;  set; }

        public int JarreteLateral { get;  set; }

        public int JarreteTras { get;  set; }

        public int UbereFirmeza { get;  set; }
        public int UberePosterior { get;  set; }

        public int AlturaUbere { get;  set; }

        public int LigamentoCentral { get;  set; }

        public int PosicaoTetos { get;  set; }
    }
}