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
            var segurado = Mapping.ToSegurado(seguradoDto);
            Add(segurado);
        }

        public IEnumerable<SeguradoGetDto> GetAllDto()
        {
            var segurados = GetAll();
            return Mapping.ToSeguradosGetDto(segurados);
        }

        public SeguradoGetDto GetByIdDto(in int id)
        {
            var segurado = GetById(id);
            return Mapping.ToSeguradoGetDto(segurado);
        }
    }
}
