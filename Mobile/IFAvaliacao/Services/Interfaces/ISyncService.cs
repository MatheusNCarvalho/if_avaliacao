using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFAvaliacao.Services.Interfaces
{
    public interface ISyncService
    {
        Task PullAsync();
        Task PushAsync();
    }
}
