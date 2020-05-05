using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Filters;
using IFAVALIACAO.API.Domain.Interfaces.Services;
using IFAVALIACAO.API.Domain.Notifications;
using IFAVALIACAO.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IFAVALIACAO.API.Controllers
{
    [Route("api/v1/vacas")]
    public class VacaController : ControllerBase
    {
        private readonly IVacaService _vacaService;

        public VacaController(IMediator bus, INotificationHandler<DomainNotification> notifications, IVacaService vacaService) : base(bus, notifications)
        {
            _vacaService = vacaService;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] SyncFilter filter)
        {
            return Response(_vacaService.SearchItemsToSync(filter));
        }

        [HttpPost]
        public IActionResult PostOrPut([FromBody] IList<VacaModel> model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }

            _vacaService.SaveAll(model);
            return Response();
        }
    }
}