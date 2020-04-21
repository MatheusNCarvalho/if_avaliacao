using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        IEnumerable<User> GetAll();
        void Add(CreateUserModel model);
    }
}