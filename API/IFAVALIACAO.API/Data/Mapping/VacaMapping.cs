using IFAVALIACAO.API.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFAVALIACAO.API.Data.Mapping
{
    public class VacaMapping : IEntityTypeConfiguration<Vaca>
    {
        public void Configure(EntityTypeBuilder<Vaca> builder)
        {
            builder.HasOne(x => x.Fazenda).WithMany().IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.VacaMae)
                .WithMany(x => x.VacasMaes)
                .HasForeignKey(x => x.VacaMaeId)
                .IsRequired(false);
        }
    }
}