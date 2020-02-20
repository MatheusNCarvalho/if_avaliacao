using IFAvaliacao.Domain.Entities;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Api
{

    [Headers("Accept: application/json", "Authorization: Bearer")]
    public interface IAvaliacaoApi
    {

        [Post("/api/v1/avaliacoes")]
        Task Post([Body] IList<AvaliacaoVaca> usuario);
    }
}
