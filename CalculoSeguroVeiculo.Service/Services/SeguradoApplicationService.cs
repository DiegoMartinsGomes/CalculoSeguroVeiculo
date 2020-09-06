using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class SeguradoApplicationService : ApplicationService<Segurado>, ISeguradoApplicationService
    {
        private readonly ISeguradoRepository _seguradoRepository;

        public SeguradoApplicationService(ISeguradoRepository seguradoRepository) : base(seguradoRepository)
        {
            _seguradoRepository = seguradoRepository;
        }
    }
}
