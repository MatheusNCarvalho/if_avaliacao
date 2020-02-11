using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Response;
using Refit;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Api
{
    [Headers("Accept: application/json")]
    public interface ICadastrarUsuarioApi
    {
        [Post("/api/v1/usuarios")]
        Task<Response<LoginResponse>> Post([Body] Usuario usuario);

    }
}
