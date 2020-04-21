using System;
using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Filters;
using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Domain.Interfaces.Services
{
    public interface IFazendaService
    {
        IList<FazendaModel> SearchItemsToSync(SyncFilter filter);
        void Save(FazendaModel model);
        void SaveOrUpdate(IList<FazendaModel> model);
        void Update(Guid id, FazendaModel model);
        void Delete(Guid id);
    }
}