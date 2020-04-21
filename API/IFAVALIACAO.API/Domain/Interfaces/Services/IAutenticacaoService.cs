using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Domain.Interfaces.Services
{
    public interface IAutenticacaoService
    {
        LoginResponseModel Login(LoginModel model);
    }
}