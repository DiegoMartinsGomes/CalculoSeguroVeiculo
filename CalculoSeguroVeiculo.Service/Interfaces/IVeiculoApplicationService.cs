using CalculoSeguroVeiculo.Crosscutting.RespostaApi;
using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface IVeiculoApplicationService
    {
        Resposta InclusaoVeiculo(VeiculoPostDto veiculoDto);
        Resposta<IEnumerable<VeiculoGetDto>> GetAllDto();
        Resposta<VeiculoGetDto> GetByIdDto(int id);
    }
}