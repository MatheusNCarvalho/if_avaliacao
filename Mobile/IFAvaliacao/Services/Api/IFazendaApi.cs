using IFAvaliacao.Domain.Entities;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Api
{

    [Headers("Accept: application/json", "Authorization: Bearer")]
    public interface IFazendaApi
    {

        [Post("/api/v1/fazendas/range")]
        Task PostOrPutAsync([Body] IList<Fazenda> usuario);
    }
}
