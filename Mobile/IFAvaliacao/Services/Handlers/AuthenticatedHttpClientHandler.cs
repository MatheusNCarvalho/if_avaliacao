using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using IFAvaliacao.Services.Api;
using IFAvaliacao.Services.Request;
using IFAvaliacao.Services.Response;
using Refit;

namespace IFAvaliacao.Services.Handlers
{
    public class AuthenticatedHttpClientHandler : DelegatingHandler
    {


        public AuthenticatedHttpClientHandler(HttpMessageHandler innerHandler = null) : base(innerHandler ?? new HttpClientHandler())
        {

        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                var securityUser = await AppSettings.GetSecurityUser(AppSettings.Usuario.Email);

                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, securityUser?.Token);
            }

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                System.Diagnostics.Debug.WriteLine("PRECISA CONSULTAR NA API PARA PEGAR UM NOVO TOKEN....");

                var accountApi = RestService.For<IAccountApi>(AppSettings.ApiUrl);

                var responseLogin = await accountApi.LoginAsync(new LoginRequest(AppSettings.Usuario?.Email, AppSettings.Usuario?.Password))
                                          .ConfigureAwait(false);


                await AppSettings.UpdateSecurityUser(AppSettings.Usuario.Email, new LoginResponse
                {
                    Token = responseLogin.Data.Token
                });

                var token = responseLogin.Data.Token;
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);

                var responseResult = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                if (responseResult.StatusCode == HttpStatusCode.InternalServerError)
                {
                    var message = await response.Content.ReadAsStringAsync()
                                        .ConfigureAwait(false);
                    throw new HttpRequestException(message);
                }

                return responseResult;
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                var message = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new HttpRequestException(message);
            }

            return response;
        }
    }
}
