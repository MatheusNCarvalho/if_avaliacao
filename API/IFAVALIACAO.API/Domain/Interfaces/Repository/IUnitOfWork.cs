using System;

namespace IFAVALIACAO.API.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}