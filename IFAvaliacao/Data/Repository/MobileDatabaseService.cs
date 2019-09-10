using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Domain.Entities;
using Xamarin.Forms;

namespace IFAvaliacao.Data.Repository
{
    public class MobileDatabaseService
    {
        public void GenerateDatabase()
        {
            var sqlConnection = DependencyService.Get<ISQLitePlatform>();
            var connection = sqlConnection.GetConnection();

            connection.CreateTable<Fazenda>();
            connection.CreateTable<Vaca>();
        }
    }
}
