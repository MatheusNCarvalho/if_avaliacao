using System;

namespace IFAVALIACAO.API.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}