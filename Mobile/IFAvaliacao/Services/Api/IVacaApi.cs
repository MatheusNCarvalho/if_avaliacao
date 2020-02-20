using IFAvaliacao.Domain.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Api
{
    [Headers("Accept: application/json", "Authorization: Bearer")]
    public interface IVacaApi
    {
        [Post("/api/v1/vacas")]
        Task PostOrPutAsync([Body] IList<Vaca> usuario);
    }
}
