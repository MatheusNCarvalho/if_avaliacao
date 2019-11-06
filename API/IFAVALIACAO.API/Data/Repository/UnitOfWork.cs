using System;
using IFAVALIACAO.API.Domain.Repository;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;

namespace IFAVALIACAO.API.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IFDbContext _context;
        private readonly IMediator _mediator;

        public UnitOfWork(IFDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _mediator.Publish(new DomainNotification("Commit", e.Message));
                return false;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}