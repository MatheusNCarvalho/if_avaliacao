

using SQLite;
using System.Threading.Tasks;

namespace IFAvaliacao.Data.Repository.Interfaces
{
    public interface ISQLitePlatform
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetConnectionAsync();
        Task DeleteDatabase();
    }
}
