using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class VeiculoApplicationService : ApplicationService<Veiculo>, IVeiculoApplicationService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoApplicationService(IVeiculoRepository veiculoRepository) : base(veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }
    }
}
