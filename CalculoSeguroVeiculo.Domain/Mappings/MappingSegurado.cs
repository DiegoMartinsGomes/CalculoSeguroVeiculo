using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
using CalculoSeguroVeiculo.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Domain.Mappings
{
    public static partial class Mapping
    {
        public static SeguradoGetDto ToSeguradoGetDto(Segurado segurado)
        {
            return new SeguradoGetDto()
            {
                Id = segurado.Id,
                Nome = segurado.Nome,
                CPF = segurado.CPF,
                Idade = segurado.Idade
            };
        }

        public static IEnumerable<SeguradoGetDto> ToSeguradosGetDto(IEnumerable<Segurado> segurados)
        {
            return segurados.Select(x => new SeguradoGetDto()
            {
                Id = x.Id,
                Nome = x.Nome,
                CPF = x.CPF,
                Idade = x.Idade
            });
        }

        public static Segurado ToSegurado(SeguradoPostDto segurado)
        {
            return new Segurado()
            {
                Nome = segurado.Nome,
                CPF = segurado.CPF,
                Idade = segurado.Idade
            };
        }
    }
}
