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

        public virtual DbSet<Veiculo> Veiculos { get; set; }
    }
}
