using System.Linq;

namespace CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
