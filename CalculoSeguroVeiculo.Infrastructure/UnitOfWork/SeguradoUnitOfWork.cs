using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces;

namespace CalculoSeguroVeiculo.Infrastructure.UnitOfWork
{
    public class SeguradoUnitOfWork : UnitOfWork, ISeguradoUnitOfWork
    {
        private readonly ISeguradoRepository _seguradoRepository;

        public SeguradoUnitOfWork(ReplyContext context, ISeguradoRepository seguradoRepository)
            : base(context)
        {
            _seguradoRepository = seguradoRepository;
        }

        public ISeguradoRepository SeguradoRepository()
        {
            return _seguradoRepository;
        }
    }
}
