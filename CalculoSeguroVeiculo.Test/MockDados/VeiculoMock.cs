using CalculoSeguroVeiculo.Domain.Models;
using System;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Test.MockDados
{
    public static class VeiculoMock
    {
        public static List<Veiculo> Dados()
        {
            var veiculos = new List<Veiculo>();
            var valorAleatório = new Random();

            for (int i = 1; i <= 10; i++)
            {
                veiculos.Add(new Veiculo()
                {
                    Id = i,
                    Marca = $"Marca{i}",
                    Modelo = $"Modelo{i}",
                    Valor = Convert.ToDecimal(valorAleatório.Next())
                });
            }

            return veiculos;
        }
    }
}
