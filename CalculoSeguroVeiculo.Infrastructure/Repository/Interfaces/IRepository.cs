using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        public void AddRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}