using CalculoSeguroVeiculo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoSeguroVeiculo.Infrastructure.Map
{
    public class SeguroMap : IEntityTypeConfiguration<Seguro>
    {
        public void Configure(EntityTypeBuilder<Seguro> builder)
        {
            builder.ToTable("Seguro");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ValorSeguro)
                .HasColumnName("ValorSeguro")
                .HasColumnType("decimal(16,2)")
                .IsRequired();

            builder.Property(x => x.DataCalculo)
                .HasColumnName("DataCalculo")
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
