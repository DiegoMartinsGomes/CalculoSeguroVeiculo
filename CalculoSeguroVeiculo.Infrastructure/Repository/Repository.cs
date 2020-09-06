using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CalculoSeguroVeiculo.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ReplyContext _context;
        private readonly DbSet<TEntity> _entity;

        public Repository(ReplyContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entity.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entity.AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return _entity.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
