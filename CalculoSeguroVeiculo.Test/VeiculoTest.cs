using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository;
using CalculoSeguroVeiculo.Service.Services;
using CalculoSeguroVeiculo.Test.MockDados;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;

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
        public void InclusaoSeguroPass()
        {
            var veiculo = new VeiculoPostDto()
            {
                Marca = $"Marca{_valorAleatorio.Next()}",
                Modelo = $"Modelo{_valorAleatorio.Next()}",
                Valor = Convert.ToDecimal(_valorAleatorio.NextDouble())
            };

            _veiculoApplicationService.InclusaoVeiculo(veiculo);
            Assert.IsNotNull(veiculo.Marca);
            Assert.IsNotNull(veiculo.Modelo);
            Assert.IsTrue(veiculo.Valor > 0);
        }

        [Test]
        public void InclusaoSeguroFail()
        {
            try
            {
                _veiculoApplicationService.InclusaoVeiculo(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Não foi possível inserir o Veiculo.", e.Message);
            }
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
        public void GetAllDtoIsNotNull()
        {
            var veiculos = _veiculoApplicationService.GetAllDto();
            Assert.IsNotNull((veiculos));
            foreach (var veiculo in veiculos)
            {
                Assert.IsNotNull(veiculo);
                Assert.IsNotNull(veiculo.Id);
                Assert.IsNotNull(veiculo.Marca);
                Assert.IsNotNull(veiculo.Modelo);
                Assert.IsNotNull(veiculo.Valor);
            }
        }

        [Test]
        public void GetByIdDtoIsNotNull()
        {
            var veiculo = _veiculoApplicationService.GetByIdDto(1);
            Assert.IsNotNull(veiculo);
            Assert.IsNotNull(veiculo.Id);
            Assert.IsNotNull(veiculo.Marca);
            Assert.IsNotNull(veiculo.Modelo);
            Assert.IsNotNull(veiculo.Valor);
        }
    }
}
