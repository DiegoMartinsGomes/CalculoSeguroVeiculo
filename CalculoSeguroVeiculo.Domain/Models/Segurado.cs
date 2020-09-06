namespace CalculoSeguroVeiculo.Domain.Models
{
    public class Segurado : Entity
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public int? Idade { get; set; }
    }
}
