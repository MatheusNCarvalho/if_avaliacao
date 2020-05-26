using System;

namespace IFAVALIACAO.API.Domain.Interfaces.Authentication
{
    public interface IUserSession
    {
        Guid UserId { get; }
    }
}