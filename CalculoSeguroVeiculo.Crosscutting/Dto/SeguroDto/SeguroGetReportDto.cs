using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Crosscutting.Dto.SeguroDto
{
    public class SeguroGetReportDto
    {
        public IEnumerable<SeguroGetDto> Seguros { get; set; }

        public string Mensagem { get; set; }

        public decimal Media { get; set; }
    }
}
