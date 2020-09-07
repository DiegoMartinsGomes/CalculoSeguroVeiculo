using CalculoSeguroVeiculo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoSeguroVeiculo.Infrastructure.Map
{
    public class SeguroMap : IEntityTypeConfiguration<Seguro>
    {
        public void Configure(EntityTypeBuilder<Seguro> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.Property(x => x.DataCalculo)
                .IsRequired();

            builder.HasOne(x => x.Segurado)
                .WithMany()
                .HasForeignKey(x => x.IdSegurado);

            builder.HasOne(x => x.Veiculo)
                .WithMany()
                .HasForeignKey(x => x.IdVeiculo);
        }
    }
}
