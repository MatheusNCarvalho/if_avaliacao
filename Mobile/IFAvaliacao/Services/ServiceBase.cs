using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public abstract class ServiceBase
    {
        private readonly IRepository<MobileServiceTableSchema> _repository;


        protected async Task<MobileServiceTableSchema> GetByTableSchemaAsync(string tableName)
        {
            var result = await _repository.GetAsync(m => m.TableName == tableName);

            if (result == null)
            {
                await InsertTableSchema(tableName);
                result = await _repository.GetAsync(m => m.TableName == tableName);
            }

            return result.FirstOrDefault();
        }


        protected async Task InsertTableSchema(string tableName)
        {
            await _repository.AddAsync(new MobileServiceTableSchema
            {
                TableName = tableName
            });
        }
    }
}
