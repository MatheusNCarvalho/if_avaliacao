using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace IFAvaliacao.Data.Repository
{
    public class FazendaReposiotry : Repository<Fazenda>, IFazendaRepository
    {
        public FazendaReposiotry(ISQLitePlatform sQLitePlatform) : base(sQLitePlatform)
        {

        }

        public async Task<bool> ExisteFazendaPorInscricaoEstadual(string inscricao, string id)
        {
            var result = await GetAsync(x => x.InscricaoEstadual == inscricao);

            if (!result.Any()) return false;

            return result.FirstOrDefault().Id != id;
        }
    }
}
