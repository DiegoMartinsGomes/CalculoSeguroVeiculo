using CalculoSeguroVeiculo.Crosscutting.RespostaApi;
using CalculoSeguroVeiculo.DataTransferObject.Relatorio.V1;
using CalculoSeguroVeiculo.DataTransferObject.Relatorio.V2;
using CalculoSeguroVeiculo.DataTransferObject.SeguroDto;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface ISeguroApplicationService
    {
        Resposta InclusaoSeguro(SeguroPostDto seguro);
        Resposta<RelatorioSeguroV1GetDto> GerarRelatorioV1();
        Resposta<RelatorioSeguroV2GetDto> GerarRelatorioV2();
        Resposta<IEnumerable<SeguroGetDto>> GetAllDto();
        Resposta<SeguroGetDto> GetByIdDto(int id);
    }
}