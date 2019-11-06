using Microsoft.IdentityModel.Tokens;

namespace IFAVALIACAO.API.Domain.Authentication
{
    public interface ISigningConfiguration
    {
        SecurityKey Key { get; }
        SigningCredentials SigningCredentials { get; }
        void GenerateKey();
    }
}