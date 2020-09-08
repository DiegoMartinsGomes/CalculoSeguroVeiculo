using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;
using CalculoSeguroVeiculo.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Domain.Mappings
{
    public static partial class Mapping
    {
        public static VeiculoGetDto ToVeiculoGetDto(Veiculo veiculo)
        {
            return new VeiculoGetDto()
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Valor = veiculo.Valor
            };
        }

        public static IEnumerable<VeiculoGetDto> ToVeiculosGetDto(IEnumerable<Veiculo> veiculos)
        {
            return veiculos.Select(x => new VeiculoGetDto()
            {
                Id = x.Id,
                Marca = x.Marca,
                Modelo = x.Modelo,
                Valor = x.Valor
            });
        }

        public static Veiculo ToVeiculo(VeiculoPostDto veiculo)
        {
            return new Veiculo()
            {
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Valor = veiculo.Valor
            };
        }
    }
}
