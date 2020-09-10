using CalculoSeguroVeiculo.DataTransferObject.Relatorio.V1;
using CalculoSeguroVeiculo.DataTransferObject.Relatorio.V2;
using CalculoSeguroVeiculo.DataTransferObject.SeguroDto;
using CalculoSeguroVeiculo.Domain.Models;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Interfaces
{
    public interface ISeguroApplicationService
    {
        void InclusaoSeguro(SeguroPostDto seguro);
        decimal CalculoSeguroVeiculo(Veiculo veiculo);
        RelatorioSeguroV1GetDto GerarRelatorioV1();
        RelatorioSeguroV2GetDto GerarRelatorioV2();
        IEnumerable<SeguroGetDto> GetAllDto();
        SeguroGetDto GetByIdDto(int id);
        IEnumerable<Seguro> GetAllRelacionado();
    }
}