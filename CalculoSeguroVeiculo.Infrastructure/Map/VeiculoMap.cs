using CalculoSeguroVeiculo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoSeguroVeiculo.Infrastructure.Map
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("VEICULO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Marca)
                .HasColumnName("MARCA")
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.Modelo)
                .HasColumnName("MODELO")
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(16,2)")
                .IsRequired();
        }
    }
}
