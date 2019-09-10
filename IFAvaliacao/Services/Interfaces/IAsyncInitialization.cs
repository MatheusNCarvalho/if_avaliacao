using System.Threading.Tasks;

namespace IFAvaliacao.Services.Interfaces
{
    public interface IAsyncInitialization
    {
        Task Initialization { get; }
    }
}
