using System;

namespace CalculoSeguroVeiculo.Domain.Models
{
    public class Seguro : Entity
    {
        public int IdSegurado { get; set; }

        public int IdVeiculo { get; set; }

        public decimal ValorSeguro { get; set; }

        public DateTime DataCalculo { get; set; }

        public Segurado Segurado { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}
