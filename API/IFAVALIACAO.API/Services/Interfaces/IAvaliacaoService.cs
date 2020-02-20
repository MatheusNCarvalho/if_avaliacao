using System.Collections.Generic;
using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        void Save(IList<AvaliacaoModel> model);
    }
}