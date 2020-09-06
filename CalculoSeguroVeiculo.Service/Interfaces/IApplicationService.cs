using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface IApplicationService<TEntity>
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
