using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Request;
using IFAvaliacao.Services.Response;
using Refit;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Api
{
    [Headers("Accept: application/json")]
    public interface IAccountApi
    {
        [Post("/api/v1/usuarios")]
        Task<Response<LoginResponse>> PostAsync([Body] Usuario usuario);

        [Post("/api/v1/login")]
        Task<Response<LoginResponse>> LoginAsync([Body] LoginRequest usuario);

    }
}
