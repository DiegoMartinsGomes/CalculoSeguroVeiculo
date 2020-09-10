using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces;

namespace CalculoSeguroVeiculo.Infrastructure.UnitOfWork
{
    public class SeguroUnitOfWork : UnitOfWork, ISeguroUnitOfWork
    {
        private readonly ISeguroRepository _seguroRepository;
        private readonly ISeguradoRepository _seguradoRepository;
        private readonly IVeiculoRepository _veiculoRepositor;

        public SeguroUnitOfWork(ReplyContext context, ISeguroRepository seguroRepository, ISeguradoRepository seguradoRepository, IVeiculoRepository veiculoRepository
            )
            : base(context)
        {
            _seguroRepository = seguroRepository;
            _seguradoRepository = seguradoRepository;
            _veiculoRepositor = veiculoRepository;
        }

        public ISeguroRepository SeguroRepository()
        {
            return _seguroRepository;
        }

        public IVeiculoRepository VeiculoRepository()
        {
            return _veiculoRepositor;
        }

        public ISeguradoRepository SeguradoRepository()
        {
            return _seguradoRepository;
        }
    }
}
