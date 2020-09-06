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

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Valor)
                .HasColumnName("Valor")
                .IsRequired();

            builder.Property(c => c.Marca)
                .HasColumnName("Marca")
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
