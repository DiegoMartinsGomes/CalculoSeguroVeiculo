using CalculoSeguroVeiculo.Crosscutting.Dto.VeiculoDto;
using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class VeiculoApplicationService : ApplicationService<Veiculo>, IVeiculoApplicationService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoApplicationService(IVeiculoRepository veiculoRepository) : base(veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public Veiculo DtoToEntity(VeiculoPostDto veiculo)
        {
            return new Veiculo()
            {
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Valor = veiculo.Valor
            };
        }

        public IEnumerable<VeiculoGetDto> EntitiesToDtos(IEnumerable<Veiculo> veiculos)
        {
            return veiculos.Select(x => new VeiculoGetDto()
            {
                Id = x.Id,
                Marca = x.Marca,
                Modelo = x.Modelo,
                Valor = x.Valor
            });
        }

        public void InclusaoVeiculo(VeiculoPostDto veiculoDto)
        {
            var veiculo = DtoToEntity(veiculoDto);
            Add(veiculo);
        }

        public IEnumerable<VeiculoGetDto> GetAllDto()
        {
            var veiculos = GetAll();
            return EntitiesToDtos(veiculos);
        }

        public VeiculoGetDto GetByIdDto(in int id)
        {
            var veiculo = GetById(id);
            return EntityToDto(veiculo);
        }

        public VeiculoGetDto EntityToDto(Veiculo veiculo)
        {
            if (veiculo == null)
                return new VeiculoGetDto();
            else
                return new VeiculoGetDto()
                {
                    Id = veiculo.Id,
                    Marca = veiculo.Marca,
                    Modelo = veiculo.Modelo,
                    Valor = veiculo.Valor
                };
        }
    }
}
