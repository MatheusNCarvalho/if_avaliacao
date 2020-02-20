using System;
using System.Collections.Generic;
using System.Text;

namespace IFAvaliacao.Extensions
{
    public static class DateTimeExtension
    {
        public static string GetDateTimeOffsetToUtc(this DateTimeOffset? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }
            return "";
        }
    }
}
