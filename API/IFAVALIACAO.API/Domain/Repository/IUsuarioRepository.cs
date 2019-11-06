using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Repository
{
    public interface IUsuarioRepository : IRepository<User>
    {
        bool ExisteEmail(string email);
        User BuscarPorEmail(string email);
    }
}