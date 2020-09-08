using System;
using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;
using CalculoSeguroVeiculo.Domain.Mappings;
using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class VeiculoApplicationService : ApplicationService<Veiculo>, IVeiculoApplicationService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoApplicationService(IVeiculoRepository veiculoRepository) : base(veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public void InclusaoVeiculo(VeiculoPostDto veiculoDto)
        {
            if (veiculoDto == null)
                throw new Exception("Não foi possível inserir o Veiculo.");
            var veiculo = Mapping.ToVeiculo(veiculoDto);
            Add(veiculo);
        }

        public IEnumerable<VeiculoGetDto> GetAllDto()
        {
            var veiculos = GetAll();
            return Mapping.ToVeiculosGetDto(veiculos);
        }

        public VeiculoGetDto GetByIdDto(int id)
        {
            var veiculo = GetById(id);
            return Mapping.ToVeiculoGetDto(veiculo);
        }
    }
}
