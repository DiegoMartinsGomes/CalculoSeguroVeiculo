using CalculoSeguroVeiculo.Crosscutting.Dto.SeguroDto;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Crosscutting.Dto.Relatorio.V2
{
    public class RelatorioSeguroV2GetDto
    {
        public IEnumerable<SeguroGetDto> Seguros { get; set; }

        public string Mensagem { get; set; }

        public decimal Media { get; set; }
    }
}
