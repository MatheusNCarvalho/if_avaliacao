﻿using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Interfaces.Services;
using IFAVALIACAO.API.Domain.Notifications;
using IFAVALIACAO.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IFAVALIACAO.API.Controllers
{

    [Route("api/v1/avaliacoes")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IMediator bus, INotificationHandler<DomainNotification> notifications, IAvaliacaoService avaliacaoService) : base(bus, notifications)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpPost]
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