using IFAvaliacao.Services.Interfaces;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public class SyncService : ISyncService
    {
        private readonly IFazendaService _fazendaService;
        private readonly IVacaService _vacaService;

        public async Task PullAsync()
        {
            await _fazendaService.PullAsync();
            await _vacaService.PullAsync();
        }

        public async Task PushAsync()
        {
            await _fazendaService.PushAsync();
            await _fazendaService.PushAsync();
        }
    }
}
