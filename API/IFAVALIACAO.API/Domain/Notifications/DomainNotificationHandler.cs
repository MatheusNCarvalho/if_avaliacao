using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;

namespace IFAVALIACAO.API.Domain.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>, IDisposable
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications => _notifications;


        public virtual bool HasNotifications() => _notifications.Any();

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}