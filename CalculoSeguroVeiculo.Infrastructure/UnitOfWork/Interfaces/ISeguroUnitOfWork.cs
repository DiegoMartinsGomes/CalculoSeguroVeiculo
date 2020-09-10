using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;

namespace CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces
{
    public interface ISeguroUnitOfWork
    {
        ISeguroRepository SeguroRepository();
        IVeiculoRepository VeiculoRepository();
        ISeguradoRepository SeguradoRepository();
    }
}
