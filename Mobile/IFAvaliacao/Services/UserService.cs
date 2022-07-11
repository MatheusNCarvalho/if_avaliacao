using System.Threading;
using IFAvaliacao.Services.Api;
using IFAvaliacao.Services.Interfaces;
using IFAvaliacao.Services.Request;
using IFAvaliacao.Services.Response;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace IFAvaliacao.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountApi _accountApi;

        public UserService()
        {
            _accountApi = RestService.For<IAccountApi>(new HttpClient
            {
                BaseAddress = new Uri(AppSettings.ApiUrl),
                Timeout = TimeSpan.FromSeconds(30)
            });
          
        }

        public async Task AddUserInCache(LoginResponse response)
        {
            if(response == null)return;
            AppSettings.Usuario = response.User;
            await AppSettings.SetSecurityUser(response.User.Email, response);
        }

        public async Task LoginAsync(string username, string senha)
        {
            var request = new LoginRequest(username, senha);

            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(30000); // 10000 ms
            var token = tokenSource.Token;

            var result = await _accountApi.LoginAsync(request, token).ConfigureAwait(false);
            result.Data.User.Password = senha;
            await AddUserInCache(result.Data);
        }
    }
}
