using System.Collections.Generic;
using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Domain.Interfaces.Services
{
    public interface IAvaliacaoService
    {
        void Save(IList<AvaliacaoModel> model);
    }
}