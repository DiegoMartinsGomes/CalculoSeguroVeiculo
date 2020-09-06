using CalculoSeguroVeiculo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculoSeguroVeiculo.Infrastructure.Map
{
    public class SeguradoMap : IEntityTypeConfiguration<Segurado>
    {
        public void Configure(EntityTypeBuilder<Segurado> builder)
        {
            builder.ToTable("Segurado");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CPF)
                .HasColumnName("CPF")
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.Idade)
                .HasColumnName("Idade")
                .IsRequired(false);
        }
    }
}
