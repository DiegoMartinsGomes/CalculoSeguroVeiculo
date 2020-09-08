using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;
using System;

namespace CalculoSeguroVeiculo.DataTransferObject.SeguroDto
{
    public class SeguroGetDto
    {
        public int Id { get; set; }

        public int IdSegurado { get; set; }

        public int IdVeiculo { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataCalculo { get; set; }

        public SeguradoGetDto Segurado { get; set; }

        public VeiculoGetDto Veiculo { get; set; }
    }
}
