using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Interfaces.Authentication;
using IFAVALIACAO.API.Domain.Parameters;
using Microsoft.IdentityModel.Tokens;

namespace IFAVALIACAO.API.Data.Authentication
{
    public class TokenEncoder : ITokenEncoder
    {
        readonly ITokenConfiguration _tokenConfiguration;
        readonly ISigningConfiguration _signingConfiguration;

        public TokenEncoder(ITokenConfiguration tokenConfiguration, ISigningConfiguration signingConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
            _signingConfiguration = signingConfiguration;
        }

        public string Encoder(User user)
        {
            var identity = new ClaimsIdentity(new[] {
                new Claim(ConfigKeys.UserId, user?.Id.ToString()),
                new Claim(ConfigKeys.Nome, user?.Name),
                new Claim(ConfigKeys.Email, user?.Email)
            });

            var creationDate = DateTime.Now;
            var expirationDate = creationDate.AddDays(_tokenConfiguration.Days);

            var handle = new JwtSecurityTokenHandler();
            var securityToken = handle.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = creationDate,
                Expires = expirationDate
            });

            return handle.WriteToken(securityToken);
        }
    }
}