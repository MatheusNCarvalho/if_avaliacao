using IFAVALIACAO.API.Domain.Interfaces.Repository;
using IFAVALIACAO.API.Domain.Notifications;
using MediatR;

namespace IFAVALIACAO.API.Domain.Services
{
    public abstract class ServiceBase
    {
        private readonly IUnitOfWork _ofWork;
        private readonly IMediator _mediator;
        private readonly DomainNotificationHandler _notifications;

        protected ServiceBase(IUnitOfWork ofWork, IMediator mediator, INotificationHandler<DomainNotification> notifications)
        {
            _ofWork = ofWork;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotifyValidationError(string key, string message)
        {
            _mediator.Publish(new DomainNotification(key, message));
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_ofWork.Commit()) return true;

            _mediator.Publish(new DomainNotification("Commit", "Tivemos um problema ao salvar seus dados."));
            return false;
        }
    }
}