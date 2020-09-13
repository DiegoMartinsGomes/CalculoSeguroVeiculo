using CalculoSeguroVeiculo.DataTransferObject.SeguroDto;
using CalculoSeguroVeiculo.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Infrastructure.Mappings
{
    public static partial class Mapping
    {
        public static SeguroGetDto ToSeguroGetDto(Seguro seguro, Segurado segurado, Veiculo veiculo)
        {
            return new SeguroGetDto()
            {
                Id = seguro.Id,
                IdSegurado = seguro.IdSegurado,
                IdVeiculo = seguro.IdVeiculo,
                DataCalculo = seguro.DataCalculo,
                Valor = seguro.Valor,
                Segurado = Mapping.ToSeguradoGetDto(segurado),
                Veiculo = Mapping.ToVeiculoGetDto(veiculo),
            };
        }

        public static IEnumerable<SeguroGetDto> ToSegurosGetDto(IEnumerable<Seguro> seguros)
        {
            return seguros.Select(x => new SeguroGetDto()
            {
                Id = x.Id,
                IdSegurado = x.IdSegurado,
                IdVeiculo = x.IdVeiculo,
                DataCalculo = x.DataCalculo,
                Valor = x.Valor,
                Segurado = Mapping.ToSeguradoGetDto(x.Segurado),
                Veiculo = Mapping.ToVeiculoGetDto(x.Veiculo)
            });
        }
    }
}
