using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Services.Request;
using IFAvaliacao.Services.Response;
using System;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public class UserService : IUserService
    {
        public async Task AddUserInCache(LoginResponse response)
        {
            AppSettings.Usuario = response.User;
            await AppSettings.SetSecurityUser(response.User.Email, response);
        }

        public async Task<bool> LoginAsync(string username, string senha)
        {

            var request = new LoginRequest(username, senha);

            return true;
        }
    }
}
