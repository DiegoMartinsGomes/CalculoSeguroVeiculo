using CalculoSeguroVeiculo.Crosscutting.Dto.Relatorio.V1;
using CalculoSeguroVeiculo.Crosscutting.Dto.Relatorio.V2;
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
        RelatorioSeguroV1GetDto RelatorioV1(IEnumerable<SeguroGetDto> seguros);
        RelatorioSeguroV2GetDto RelatorioV2(IEnumerable<SeguroGetDto> seguros);
    }
}
