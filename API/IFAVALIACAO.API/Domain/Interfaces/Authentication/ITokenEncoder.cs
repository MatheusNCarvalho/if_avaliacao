using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Interfaces.Authentication
{
    public interface ITokenEncoder
    {
        string Encoder(User user);
    }
}