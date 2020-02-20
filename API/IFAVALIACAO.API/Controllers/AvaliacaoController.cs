using System.Collections.Generic;
using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Services.Interfaces;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IFAVALIACAO.API.Controllers
{
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IMediator bus, INotificationHandler<DomainNotification> notifications, IAvaliacaoService avaliacaoService) : base(bus, notifications)
        {
            _avaliacaoService = avaliacaoService;
        }

        public IActionResult Post([FromBody] IList<AvaliacaoModel> models)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }
            _avaliacaoService.Save(models);
            return Response();
        }
    }
}