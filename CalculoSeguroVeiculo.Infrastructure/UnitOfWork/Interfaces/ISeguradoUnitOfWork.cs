using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;

namespace CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces
{
    public interface ISeguradoUnitOfWork
    {
        ISeguradoRepository SeguradoRepository();
    }
}
