using Microsoft.IdentityModel.Tokens;

namespace IFAVALIACAO.API.Domain.Interfaces.Authentication
{
    public interface ISigningConfiguration
    {
        SecurityKey Key { get; }
        SigningCredentials SigningCredentials { get; }
        void GenerateKey();
    }
}