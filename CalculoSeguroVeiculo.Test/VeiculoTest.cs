using CalculoSeguroVeiculo.Crosscutting.Dto.VeiculoDto;
using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository;
using CalculoSeguroVeiculo.Service.Services;
using CalculoSeguroVeiculo.Test.MockDados;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Test
{
    [TestFixture]
    public class VeiculoTest
    {
        private readonly ReplyContext _context;
        private readonly VeiculoRepository _veiculoRepository;
        private readonly VeiculoApplicationService _veiculoApplicationService;
        private readonly Random _valorAleatorio;


        public VeiculoTest()
        {
            _context = new ReplyContext(new DbContextOptionsBuilder<ReplyContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _context.Veiculo.AddRange(VeiculoMock.Dados());
            _context.SaveChanges();

            _veiculoRepository = new VeiculoRepository(_context);
            _veiculoApplicationService = new VeiculoApplicationService(_veiculoRepository);
            _valorAleatorio = new Random();
        }

        [Test]
        public void AddPass()
        {
            var veiculo = new Veiculo()
            {
                Marca = $"Marca{_valorAleatorio.Next()}",
                Modelo = $"Modelo{_valorAleatorio.Next()}",
                Valor = Convert.ToDecimal(_valorAleatorio.NextDouble())
            };

            _veiculoApplicationService.Add(veiculo);

            Assert.IsNotNull(veiculo.Marca);
            Assert.IsNotNull(veiculo.Modelo);
            Assert.IsTrue(veiculo.Valor > 0);
        }

        [Test]
        public void AddFail()
        {
            var veiculo = new Veiculo();
            _veiculoApplicationService.Add(veiculo);

            Assert.IsNull(veiculo.Marca);
            Assert.IsNull(veiculo.Modelo);
            Assert.IsFalse(veiculo.Valor > 0);
        }

        [Test]
        public void TestGetIdNotNull()
        {
            var id = 1;
            var veiculo = _veiculoApplicationService.GetById(id);

            Assert.NotNull(veiculo);
            Assert.NotNull(veiculo.Id = id);
        }

        [Test]
        public void TestGetIdIsNull()
        {
            var id = 0;
            var veiculo = _veiculoApplicationService.GetById(id);

            Assert.IsNull(veiculo);
        }

        [Test]
        public void TestGetAllNotNull()
        {
            var veiculos = _veiculoApplicationService.GetAll();

            Assert.NotNull(veiculos);
        }

        [Test]
        public void TestGetAllIsNull()
        {
            int id = 0;
            var veiculos = _veiculoApplicationService.GetAll().Where(x => x.Id == id);

            Assert.IsEmpty(veiculos);
        }

        [Test]
        public void DtoToEntityIsNotNull()
        {
            var veiculo = _veiculoApplicationService.DtoToEntity(new VeiculoPostDto());

            Assert.IsNotNull(veiculo);
        }

        [Test]
        public void EntitiesToDtosIsNotNull()
        {
            var veiculos = _veiculoApplicationService.EntitiesToDtos(new List<Veiculo>());

            Assert.IsNotNull(veiculos);
        }

        [Test]
        public void EntityToDtoIsNotNull()
        {
            var veiculos = _veiculoApplicationService.EntityToDto(new Veiculo());

            Assert.IsNotNull(veiculos);
        }
    }
}
