using System;
using System.Collections.Generic;
using IFAVALIACAO.API.Domain.Filters;
using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Domain.Interfaces.Services
{
    public interface IVacaService
    {
        IList<VacaModel> SearchItemsToSync(SyncFilter syncFilter);
        void Save(VacaModel model);
        void SaveAll(IList<VacaModel> models);
        void Update(Guid id, VacaModel model);
        void Delete(Guid id);
    }
}