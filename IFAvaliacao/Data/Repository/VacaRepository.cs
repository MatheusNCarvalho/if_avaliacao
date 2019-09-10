using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;

namespace IFAvaliacao.Data.Repository
{
    public class VacaRepository : Repository<Vaca>, IVacaRepository
    {       
        public VacaRepository(ISQLitePlatform sQLitePlatform) : base(sQLitePlatform)
        {
           
        }
    }
}
