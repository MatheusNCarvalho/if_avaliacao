using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Entites;
using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Services.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<User> GetAll();
        void Add(UserModel model);
    }
}