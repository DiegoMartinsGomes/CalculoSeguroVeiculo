using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
using CalculoSeguroVeiculo.Domain.Models;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface ISeguradoApplicationService : IApplicationService<Segurado>
    {
        void InclusaoSegurado(SeguradoPostDto seguradoDto);
        IEnumerable<SeguradoGetDto> GetAllDto();
        SeguradoGetDto GetByIdDto(int id);
    }
}
