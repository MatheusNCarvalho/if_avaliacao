using IFAvaliacao.Services.Handlers;
using System;
using System.Net.Http;

namespace IFAvaliacao.Services.Api
{
    public class HttpClientInstance
    {
        private static HttpClient _instance;

        public static HttpClient Current => _instance
           ?? (_instance = new HttpClient(new AuthenticatedHttpClientHandler()) 
           { 
               BaseAddress = new Uri(AppSettings.ApiUrl),
               Timeout = TimeSpan.FromSeconds(40)
           });
    }
}
