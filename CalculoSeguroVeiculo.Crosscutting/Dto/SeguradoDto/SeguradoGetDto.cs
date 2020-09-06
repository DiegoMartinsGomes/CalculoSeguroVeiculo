namespace CalculoSeguroVeiculo.Crosscutting.Dto.SeguradoDto
{
    public class SeguradoGetDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public int? Idade { get; set; }
    }
}
