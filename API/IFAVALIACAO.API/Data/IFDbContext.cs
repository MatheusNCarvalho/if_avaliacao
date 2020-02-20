using IFAVALIACAO.API.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace IFAVALIACAO.API.Data
{
    public class IFDbContext : DbContext
    {
        public IFDbContext(DbContextOptions<IFDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new FazendaMapping());
            modelBuilder.ApplyConfiguration(new VacaMapping());
        }
    }
}