using IFAVALIACAO.API.Domain.Extension;
using IFAVALIACAO.API.Domain.Interfaces.Authentication;
using IFAVALIACAO.API.Domain.Interfaces.Repository;
using IFAVALIACAO.API.Domain.Interfaces.Services;
using IFAVALIACAO.API.Domain.Notifications;
using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Resources;
using MediatR;

namespace IFAVALIACAO.API.Domain.Services
{
    public class AutenticacaoService : ServiceBase, IAutenticacaoService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenEncoder _tokenEncoder;

        public AutenticacaoService(IUnitOfWork ofWork, 
            IMediator mediator, 
            INotificationHandler<DomainNotification> notifications, 
            IUsuarioRepository usuarioRepository, 
            ITokenEncoder tokenEncoder) : base(ofWork, mediator, notifications)
        {
            _usuarioRepository = usuarioRepository;
            _tokenEncoder = tokenEncoder;
        }

        public LoginResponseModel Login(LoginModel model)
        {
            var usuario = _usuarioRepository.BuscarPorEmail(model.Email);

            if (usuario == null || usuario.Password != model.Password.Encrypt())
            {
                NotifyValidationError(nameof(DomainError.UserLoginInvalido), DomainError.UserLoginInvalido);
                return null;
            }

            var token = _tokenEncoder.Encoder(usuario);
            return new LoginResponseModel
            {
                Nome = usuario.Name,
                Token = token,
                User = new UserModel
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Name = usuario.Name,
                    DataCriacao = usuario.DataCriacao,
                    DataAtualizacao = usuario.DataAtualizacao
                }
            };
        }
    }
}