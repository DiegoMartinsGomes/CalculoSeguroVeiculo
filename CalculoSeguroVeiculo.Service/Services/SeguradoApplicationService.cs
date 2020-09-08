using System;
using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
using CalculoSeguroVeiculo.Domain.Mappings;
using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class SeguradoApplicationService : ApplicationService<Segurado>, ISeguradoApplicationService
    {
        private readonly ISeguradoRepository _seguradoRepository;

        public SeguradoApplicationService(ISeguradoRepository seguradoRepository) : base(seguradoRepository)
        {
            _seguradoRepository = seguradoRepository;
        }

        public void InclusaoSegurado(SeguradoPostDto seguradoDto)
        {
            if (seguradoDto == null)
                throw new Exception("Não foi possível Inserir o Segurado");
            var segurado = Mapping.ToSegurado(seguradoDto);
            Add(segurado);
        }

        public IEnumerable<SeguradoGetDto> GetAllDto()
        {
            var segurados = GetAll();
            return Mapping.ToSeguradosGetDto(segurados);
        }

        public SeguradoGetDto GetByIdDto(int id)
        {
            var segurado = GetById(id);
            if(segurado == null)
                throw new Exception("Não foi possível localizar o Segurado");
            return Mapping.ToSeguradoGetDto(segurado);
        }
    }
}
