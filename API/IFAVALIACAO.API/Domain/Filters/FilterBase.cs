using System;

namespace IFAVALIACAO.API.Domain.Filters
{
    public class FilterBase
    {
        public bool PrimeiraSincronizacao { get; set; }
        public DateTime UltimaDataSincronizacao { get; set; }

    }
}