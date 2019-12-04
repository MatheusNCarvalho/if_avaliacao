using System;
using IFAVALIACAO.API.Models;

namespace IFAVALIACAO.API.Services.Interfaces
{
    public interface IVacaService
    {
        void Save(VacaModel model);
        void Update(Guid id, VacaModel model);
        void Delete(Guid id);
    }
}