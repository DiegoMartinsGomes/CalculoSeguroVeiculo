using System.Threading.Tasks;

namespace CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
