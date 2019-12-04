using System;
using System.Collections.Generic;
using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Services.Interfaces
{
    public interface IFazendaService
    {
        void Save(FazendaModel model);
        void Save(IList<FazendaModel> model);
        void Update(Guid id, FazendaModel model);
        void Delete(Guid id);
    }
}