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

    [Route("api/v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAutenticacaoService _autenticacaoService;

        public UsuarioController(IUsuarioService usuarioService, IMediator bus, INotificationHandler<DomainNotification> notifications, IAutenticacaoService autenticacaoService) : base(bus, notifications)
        {
            _usuarioService = usuarioService;
            _autenticacaoService = autenticacaoService;
        }


        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _usuarioService.GetAll();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }

            _usuarioService.Add(model);

            if (IsValidOperation()) return Response(null, 201);

            var result = _autenticacaoService.Login(new LoginModel { Email = model.Email, Password = model.Password });
            return Response(result);
        }
    }
}