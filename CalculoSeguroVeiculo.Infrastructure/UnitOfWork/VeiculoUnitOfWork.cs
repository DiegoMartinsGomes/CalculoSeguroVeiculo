using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces;

namespace CalculoSeguroVeiculo.Infrastructure.UnitOfWork
{
    public class VeiculoUnitOfWork : UnitOfWork, IVeiculoUnitOfWork
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoUnitOfWork(ReplyContext context, IVeiculoRepository veiculoRepository)
            : base(context)
        {
            _veiculoRepository = veiculoRepository;
        }

        IVeiculoRepository IVeiculoUnitOfWork.VeiculoRepository()
        {
            return _veiculoRepository;
        }
    }
}
