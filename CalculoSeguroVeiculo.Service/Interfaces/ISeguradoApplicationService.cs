using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
using System.Collections.Generic;
using CalculoSeguroVeiculo.Crosscutting.RespostaApi;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface ISeguradoApplicationService
    {
        Resposta InclusaoSegurado(SeguradoPostDto seguradoDto);
        Resposta<IEnumerable<SeguradoGetDto>> GetAllDto();
        Resposta<SeguradoGetDto> GetByIdDto(int id);
    }
}