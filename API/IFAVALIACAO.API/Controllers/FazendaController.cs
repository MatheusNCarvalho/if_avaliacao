using System.Collections.Generic;
using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Services.Interfaces;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IFAVALIACAO.API.Controllers
{
    [Route("api/v1/fazendas")]
    public class FazendaController : ControllerBase
    {
        private readonly IFazendaService _fazendaService;
        public FazendaController(IMediator bus, INotificationHandler<DomainNotification> notifications, IFazendaService fazendaService) : base(bus, notifications)
        {
            _fazendaService = fazendaService;
        }


        [HttpPost]
        public IActionResult Post([FromBody] FazendaModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }

            _fazendaService.Save(model);
            return Response();
        }

        [HttpPost("range")]
        public IActionResult Post([FromBody] IList<FazendaModel> model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }

            _fazendaService.SaveOrUpdate(model);
            return Response();
        }
    }
}