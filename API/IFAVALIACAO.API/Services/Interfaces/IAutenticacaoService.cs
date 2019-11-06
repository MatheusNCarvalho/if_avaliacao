using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        LoginResponseModel Login(LoginModel model);
    }
}