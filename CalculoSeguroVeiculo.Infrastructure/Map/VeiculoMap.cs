using CalculoSeguroVeiculo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoSeguroVeiculo.Infrastructure.Map
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Marca)
                .HasColumnName("Marca")
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.Modelo)
                .HasColumnName("Modelo")
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal(16,2)")
                .IsRequired();
        }
    }
}
