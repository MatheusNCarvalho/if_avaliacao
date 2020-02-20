using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;

namespace IFAvaliacao.Data.Repository
{
    public class MobileTableSchemaRepository : Repository<MobileTableSchema>, IMobileTableSchemaRepository
    {
        public MobileTableSchemaRepository(ISQLitePlatform sQLitePlatform) : base(sQLitePlatform)
        {
        }
    }
}
