using System.Threading.Tasks;
using Refit;

namespace IFAvaliacao.Services.Api
{
    public interface IFindZipCodeApi
    {
        [Get("/{zipCode}/json/")]
        Task<ZipCodeResponse> FindZipCodeAsync(string zipCode);
    }


    public class ZipCodeResponse
    {
        public bool Erro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }

    }
}
