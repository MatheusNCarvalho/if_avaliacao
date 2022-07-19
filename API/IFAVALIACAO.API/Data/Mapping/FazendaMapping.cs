using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFAVALIACAO.API.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFAVALIACAO.API.Data.Mapping
{
    public class FazendaMapping : IEntityTypeConfiguration<Fazenda>
    {
        public void Configure(EntityTypeBuilder<Fazenda> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
