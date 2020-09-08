using CalculoSeguroVeiculo.DataTransferObject.SeguroDto;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.DataTransferObject.Relatorio.V2
{
    public class RelatorioSeguroV2GetDto
    {
        public IEnumerable<SeguroGetDto> Seguros { get; set; }

        public string Mensagem { get; set; }

        public decimal Media { get; set; }
    }
}
