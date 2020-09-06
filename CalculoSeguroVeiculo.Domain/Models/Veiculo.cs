namespace CalculoSeguroVeiculo.Domain.Models
{
    public class Veiculo : Entity
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public decimal Valor { get; set; }
    }
}
