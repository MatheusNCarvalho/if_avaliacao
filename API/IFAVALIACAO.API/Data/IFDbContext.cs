using Microsoft.EntityFrameworkCore;

namespace IFAVALIACAO.API.Data
{
    public class IFDbContext : DbContext
    {
        public IFDbContext(DbContextOptions<IFDbContext> options) : base(options)
        {

        }




    }
}