using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;

namespace CalculoSeguroVeiculo.Infrastructure.Repository
{
    public class SeguradoRepository : Repository<Segurado>, ISeguradoRepository
    {
        public SeguradoRepository(ReplyContext context) : base(context)
        {
        }
    }
}
