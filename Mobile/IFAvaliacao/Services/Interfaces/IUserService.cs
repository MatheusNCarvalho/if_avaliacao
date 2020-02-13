using IFAvaliacao.Services.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> LoginAsync(string username, string senha);
        Task AddUserInCache(LoginResponse response);
    }
}
