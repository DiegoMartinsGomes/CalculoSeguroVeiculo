using CalculoSeguroVeiculo.Domain.Models;
using System;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Test.MockDados
{
    public static class SeguradoMock
    {
        public static List<Segurado> Dados()
        {
            var segurados = new List<Segurado>();
            var valorAleatório = new Random();

            for (int i = 1; i <= 10; i++)
            {
                segurados.Add(new Segurado()
                {
                    Id = i,
                    Nome = $"Nome{i}",
                    CPF = $"{12345678910 * valorAleatório.Next()}".Substring(0, 11),
                    Idade = valorAleatório.Next(18, 100)
                });
            }

            return segurados;
        }
    }
}
