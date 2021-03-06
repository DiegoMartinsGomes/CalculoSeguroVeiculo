﻿using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;

namespace CalculoSeguroVeiculo.Infrastructure.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(ReplyContext context) : base(context)
        {
        }
    }
}
