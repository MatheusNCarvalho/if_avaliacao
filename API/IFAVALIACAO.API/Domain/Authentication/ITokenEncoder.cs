using IFAVALIACAO.API.Domain.Entites;

namespace IFAVALIACAO.API.Domain.Authentication
{
    public interface ITokenEncoder
    {
        string Encoder(User user);
    }
}