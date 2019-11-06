using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Services.Interfaces;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFAVALIACAO.API.Controllers
{

    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, IMediator bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _usuarioService = usuarioService;
        }


        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _usuarioService.GetAll();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }

            _usuarioService.Add(model);
            return Response(null, 201);
        }
    }
}