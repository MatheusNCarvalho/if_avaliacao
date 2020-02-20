using IFAvaliacao.Services.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Api
{
    [Headers("Accept: application/json", "Authorization: Bearer")]
    public interface IBaseServiceApi<T> where T : class
    {
        [Get("/api/v1/{controller}")]
        Task<Response<List<T>>> GetAsync(string controller, bool firstSync, string lastDateStard);
    }
}
