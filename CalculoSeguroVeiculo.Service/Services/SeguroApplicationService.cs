using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class SeguroApplicationService : ApplicationService<Seguro>, ISeguroApplicationService
    {
        private readonly ISeguroRepository _seguroRepository;

        public SeguroApplicationService(ISeguroRepository seguroRepository) : base(seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }
    }
}
