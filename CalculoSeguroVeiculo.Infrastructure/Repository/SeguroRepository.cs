using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;

namespace CalculoSeguroVeiculo.Infrastructure.Repository
{
    public class SeguroRepository : Repository<Seguro>, ISeguroRepository
    {
        public SeguroRepository(ReplyContext context) : base(context)
        {
        }
    }
}
