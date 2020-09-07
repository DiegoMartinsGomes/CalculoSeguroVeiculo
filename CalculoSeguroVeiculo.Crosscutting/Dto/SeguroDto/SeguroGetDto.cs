using CalculoSeguroVeiculo.Crosscutting.Dto.SeguradoDto;
using CalculoSeguroVeiculo.Crosscutting.Dto.VeiculoDto;
using System;

namespace CalculoSeguroVeiculo.Crosscutting.Dto.SeguroDto
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
