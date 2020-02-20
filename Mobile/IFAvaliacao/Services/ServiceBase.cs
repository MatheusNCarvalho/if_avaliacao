using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Extensions;
using IFAvaliacao.Services.Api;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFAvaliacao.Services
{
    public abstract class ServiceBase
    {
        private readonly IMobileTableSchemaRepository _mobileTableSchemaRepository;

        protected ServiceBase(IMobileTableSchemaRepository repository)
        {
            _mobileTableSchemaRepository = repository;
        }

        protected async Task<MobileTableSchema> GetByTableSchemaAsync(string tableName)
        {
            var result = await _mobileTableSchemaRepository.GetAsync(m => m.TableName == tableName);

            if (result.FirstOrDefault() == null)
            {
                await InsertTableSchemaAsync(tableName);
                result = await _mobileTableSchemaRepository.GetAsync(m => m.TableName == tableName);
            }

            return result.FirstOrDefault();
        }


        protected async Task InsertTableSchemaAsync(string tableName)
        {
            await _mobileTableSchemaRepository.AddAsync(new MobileTableSchema
            {
                TableName = tableName
            });
        }

        protected async Task UpdateTableSchemaAsync(MobileTableSchema schema)
        {
            await _mobileTableSchemaRepository.UpdateAsync(schema);
        }

        protected async Task<IList<TResponse>> GetAsync<TResponse>(string controller, bool firstSync, DateTimeOffset? lastDateStard) where TResponse : EntityBase
        {
            var lastDateStardString = lastDateStard.GetDateTimeOffsetToUtc();

            var api = RestService.For<IBaseServiceApi<TResponse>>(HttpClientInstance.Current);
            var response = await api.GetAsync(controller, firstSync, lastDateStardString).ConfigureAwait(false);
            return response.Data;
        }
    }
}
