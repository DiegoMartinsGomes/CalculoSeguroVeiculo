using CalculoSeguroVeiculo.Crosscutting.Dto.SeguradoDto;
using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class SeguradoApplicationService : ApplicationService<Segurado>, ISeguradoApplicationService
    {
        private readonly ISeguradoRepository _seguradoRepository;

        public SeguradoApplicationService(ISeguradoRepository seguradoRepository) : base(seguradoRepository)
        {
            _seguradoRepository = seguradoRepository;
        }

        public Segurado DtoToEntity(SeguradoPostDto segurado)
        {
            return new Segurado()
            {
                Nome = segurado.Nome,
                CPF = segurado.CPF,
                Idade = segurado.Idade
            };
        }

        public IEnumerable<SeguradoGetDto> EntitiesToDtos(IEnumerable<Segurado> segurados)
        {
            return segurados.Select(x => new SeguradoGetDto()
            {
                Id = x.Id,
                Nome = x.Nome,
                CPF = x.CPF,
                Idade = x.Idade
            });
        }

        public SeguradoGetDto EntityToDto(Segurado segurado)
        {
            return new SeguradoGetDto()
            {
                Id = segurado.Id,
                Nome = segurado.Nome,
                CPF = segurado.CPF,
                Idade = segurado.Idade
            };
        }
    }
}
