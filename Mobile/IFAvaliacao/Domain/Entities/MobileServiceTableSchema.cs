using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFAvaliacao.Domain.Entities
{
    [Table("__mobileServiceTableSchema")]
    public class MobileServiceTableSchema : EntityBase
    {
        public string TableName { get; set; }
        public DateTimeOffset? LastSync { get; set; }
        
        public void SetLastSync(DateTimeOffset lastSync)
        {
            LastSync = lastSync;
        }
    }
}
