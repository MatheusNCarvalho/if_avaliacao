using System.Linq;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Repository;

namespace IFAVALIACAO.API.Data.Repository
{
    public class UsuarioRepository : Repository<User>, IUsuarioRepository
    {
        public UsuarioRepository(IFDbContext context) : base(context)
        {
        }

        public bool ExisteEmail(string email)
        {
            return GetAll().Any(x => x.Email == email);
        }

        public User BuscarPorEmail(string email)
        {
            return GetAll().FirstOrDefault(x => x.Email == email);
        }
    }
}