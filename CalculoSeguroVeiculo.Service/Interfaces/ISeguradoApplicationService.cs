using CalculoSeguroVeiculo.Crosscutting.Dto.SeguradoDto;
using CalculoSeguroVeiculo.Domain.Models;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface ISeguradoApplicationService : IApplicationService<Segurado>
    {
        SeguradoGetDto EntityToDto(Segurado segurado);
        Segurado DtoToEntity(SeguradoPostDto seguradoDto);
        IEnumerable<SeguradoGetDto> EntitiesToDtos(IEnumerable<Segurado> segurados);
    }
}
