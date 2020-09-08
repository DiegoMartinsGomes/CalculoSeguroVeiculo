using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;
using CalculoSeguroVeiculo.Domain.Models;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface IVeiculoApplicationService : IApplicationService<Veiculo>
    {
        void InclusaoVeiculo(VeiculoPostDto veiculoDto);
        IEnumerable<VeiculoGetDto> GetAllDto();
        VeiculoGetDto GetByIdDto(int id);
    }
}
