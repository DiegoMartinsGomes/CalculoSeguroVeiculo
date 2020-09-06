using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class ApplicationService<TEntity> : IApplicationService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public ApplicationService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
