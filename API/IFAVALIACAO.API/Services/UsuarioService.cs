using System.Collections.Generic;
using System.Linq;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Domain.Extension;
using IFAVALIACAO.API.Domain.Repository;
using IFAVALIACAO.API.Models;
using IFAVALIACAO.API.Resources;
using IFAVALIACAO.API.Services.Interfaces;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;

namespace IFAVALIACAO.API.Services
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUnitOfWork ofWork, IMediator mediator, INotificationHandler<DomainNotification> notifications, IUsuarioRepository usuarioRepository) : base(ofWork, mediator, notifications)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _usuarioRepository.GetAll().ToList();
        }

        public void Add(UserModel model)
        {
            if (_usuarioRepository.ExisteEmail(model.Email))
            {
                NotifyValidationError(nameof(DomainError.UserEmailDuplicado), string.Format(DomainError.UserEmailDuplicado, model.Email));
                return;
            }

            var user = new User(model.Name, model.Email, model.Password.Encrypt());
            _usuarioRepository.Add(user);
            Commit();
        }
    }
}