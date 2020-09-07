using CalculoSeguroVeiculo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Test.MockDados
{
    public static class SeguroMock
    {
        public static List<Seguro> Dados(List<Segurado> segurados, List<Veiculo> veiculos)
        {
            var seguros = new List<Seguro>();
            var valorAleatório = new Random();

            int i = 1, d = 10;
            while (i <= 10 && d >= 1)
            {
                var segurado = segurados.Where(x => x.Id == i).FirstOrDefault();
                var veiculo = veiculos.Where(x => x.Id == d).FirstOrDefault();

                seguros.Add(new Seguro()
                {
                    Id = i,
                    IdSegurado = segurado.Id,
                    IdVeiculo = veiculo.Id,
                    DataCalculo = DateTime.Now,
                    Segurado = segurado,
                    Veiculo = veiculo,
                    Valor = Convert.ToDecimal(valorAleatório.Next())
                });

                i++;
                d--;
            }

            return seguros;
        }
    }
}
