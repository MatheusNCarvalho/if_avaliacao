using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;

namespace IFAvaliacao.Data.Repository
{
    public class AvaliacaoRepository : Repository<AvaliacaoVaca>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(ISQLitePlatform sQLitePlatform) : base(sQLitePlatform)
        {
        }
    }
}
