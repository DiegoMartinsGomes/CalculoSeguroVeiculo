using CalculoSeguroVeiculo.Crosscutting.Dto.SeguroDto;
using CalculoSeguroVeiculo.Domain.Models;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface ISeguroApplicationService : IApplicationService<Seguro>
    {
        void InclusaoSeguro(SeguroPostDto seguro);
        SeguroGetDto EntityToDto(Seguro seguro);
        IEnumerable<SeguroGetDto> EntitiesToDtos(IEnumerable<Seguro> seguros);
        decimal CalculoSeguroVeiculo(Veiculo veiculo);
        SeguroGetReportDto Relatorio(IEnumerable<SeguroGetDto> seguros);
    }
}
