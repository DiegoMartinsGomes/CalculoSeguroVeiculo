using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces;
using System;

namespace CalculoSeguroVeiculo.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ReplyContext Context { get; set; }

        public UnitOfWork(ReplyContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.ChangeTracker.DetectChanges();
            Context.SaveChanges();
        }
    }
}
