using CalculoSeguroVeiculo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculoSeguroVeiculo.Infrastructure.Context
{
    public class ReplyContext : DbContext
    {
        public ReplyContext(DbContextOptions<ReplyContext> options) : base(options) =>
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        public ReplyContext() =>
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public virtual DbSet<Segurado> Segurado { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<Seguro> Seguro { get; set; }
    }
}
