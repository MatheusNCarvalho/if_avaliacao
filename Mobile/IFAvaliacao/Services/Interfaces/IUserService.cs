using IFAvaliacao.Services.Response;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Interfaces
{
    public interface IUserService
    {
        Task LoginAsync(string username, string senha);
        Task AddUserInCache(LoginResponse response);
    }
}
