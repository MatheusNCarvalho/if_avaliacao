using System.Linq;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IFAVALIACAO.API.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        protected readonly IMediator Bus;

        protected ControllerBase(IMediator bus, INotificationHandler<DomainNotification> notifications)
        {
            Bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }




        protected new IActionResult Response(object result = null, int statusCode = 200)
        {
            if (!IsValidOperation())
            {
                return StatusCode(statusCode, new { data = result });
            }

            var errorMessages = _notifications.GetNotifications;

            return BadRequest(new { message = string.Join("\n", errorMessages.Select(x => x.Value)) });
        }

        private bool IsValidOperation()
        {
            return _notifications.HasNotifications();
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(x => x.Errors);

            AddNotifyError("ModelError", string.Join("\n", erros.Select(err => err.Exception == null ? err.ErrorMessage : err.Exception.Message)));
        }

        void AddNotifyError(string key, string message)
        {
            Bus.Publish(new DomainNotification(key, message));
        }
    }
}