using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface IVeiculoApplicationService
    {
        void InclusaoVeiculo(VeiculoPostDto veiculoDto);
        IEnumerable<VeiculoGetDto> GetAllDto();
        VeiculoGetDto GetByIdDto(int id);
    }
}