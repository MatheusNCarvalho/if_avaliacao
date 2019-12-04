using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Services.Interfaces;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFAVALIACAO.API.Controllers
{
    [Route("api/v1/")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;
        public AutenticacaoController(IMediator bus, INotificationHandler<DomainNotification> notifications, IAutenticacaoService autenticacaoService) : base(bus, notifications)
        {
            _autenticacaoService = autenticacaoService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }

            var result = _autenticacaoService.Login(model);
            return Response(result);
        }
    }
}