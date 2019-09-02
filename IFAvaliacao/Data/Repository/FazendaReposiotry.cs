using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;

namespace IFAvaliacao.Data.Repository
{
    public class FazendaReposiotry : Repository<Fazenda>, IFazendaRepository
    {
        public FazendaReposiotry(ISQLitePlatform sQLitePlatform) : base(sQLitePlatform)
        {
        }
    }
}
