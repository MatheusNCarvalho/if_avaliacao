using IFAvaliacao.Services.Api;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Services.Request;
using IFAvaliacao.Services.Response;
using Refit;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountApi _accountApi;

        public UserService()
        {
            _accountApi = RestService.For<IAccountApi>(AppSettings.ApiUrl);
        }

        public async Task AddUserInCache(LoginResponse response)
        {
            AppSettings.Usuario = response.User;
            await AppSettings.SetSecurityUser(response.User.Email, response);
        }

        public async Task LoginAsync(string username, string senha)
        {
            var request = new LoginRequest(username, senha);

            var result = await _accountApi.LoginAsync(request).ConfigureAwait(false);
            result.Data.User.Password = senha;
            await AddUserInCache(result.Data);
        }
    }
}
