using System;
using System.IO;
using System.Threading.Tasks;
using IFAvaliacao.Data.Repository.Interfaces;
using IFAvaliacao.Droid.Services;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLitePlatform))]
namespace IFAvaliacao.Droid.Services
{

    public class AndroidSQLitePlatform : ISQLitePlatform
    {
        private const string dbName = "tmx.db3";
        private static SQLiteConnection _connection;
        private static SQLiteAsyncConnection _connectionAsync;

        public SQLiteConnection GetConnection()
        {
            try
            {
                return _connection ?? (_connection = new SQLiteConnection(GetPath()));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
                throw;
            }
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            try
            {
                return _connectionAsync ?? (_connectionAsync = new SQLiteAsyncConnection(GetPath()));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
                throw;
            }
        }

        public async Task DeleteDatabase()
        {
            _connection?.Close();
            await _connectionAsync?.CloseAsync();
            File.Delete(GetPath());
        }

        private string GetPath()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
            return path;
        }
    }
}