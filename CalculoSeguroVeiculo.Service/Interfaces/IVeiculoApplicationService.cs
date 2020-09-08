using CalculoSeguroVeiculo.Crosscutting.Dto.VeiculoDto;
using CalculoSeguroVeiculo.Domain.Models;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface IVeiculoApplicationService : IApplicationService<Veiculo>
    {
        VeiculoGetDto EntityToDto(Veiculo veiculo);
        Veiculo DtoToEntity(VeiculoPostDto veiculo);
        IEnumerable<VeiculoGetDto> EntitiesToDtos(IEnumerable<Veiculo> veiculos);
        void InclusaoVeiculo(VeiculoPostDto veiculoDto);
        IEnumerable<VeiculoGetDto> GetAllDto();
        VeiculoGetDto GetByIdDto(in int id);
    }
}
