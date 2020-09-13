using CalculoSeguroVeiculo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoSeguroVeiculo.Infrastructure.Map
{
    public class SeguroMap : IEntityTypeConfiguration<Seguro>
    {
        public void Configure(EntityTypeBuilder<Seguro> builder)
        {
            builder.ToTable("SEGURO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Valor)
                .HasColumnName("VALORSEGURO")
                .HasColumnType("decimal(16,2)")
                .IsRequired();

            builder.Property(x => x.DataCalculo)
                .HasColumnName("DATACALCULO")
                .HasColumnType("datetime")
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
