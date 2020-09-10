using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface ISeguradoApplicationService
    {
        void InclusaoSegurado(SeguradoPostDto seguradoDto);
        IEnumerable<SeguradoGetDto> GetAllDto();
        SeguradoGetDto GetByIdDto(int id);
    }
}