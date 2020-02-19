using System;

namespace IFAVALIACAO.API.Domain.Filters
{
    public class SyncFilter
    {
        public bool FirstSync { get; set; }
        public DateTimeOffset? LastDateStart { get; set; }
    }
}