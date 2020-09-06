﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface IApplicationService<TEntity>
    {
        void Add(TEntity entity);

        List<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
