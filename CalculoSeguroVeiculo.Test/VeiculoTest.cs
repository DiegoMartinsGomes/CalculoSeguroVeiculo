using CalculoSeguroVeiculo.Crosscutting.Enums;
using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;
using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork;
using CalculoSeguroVeiculo.Service.Services;
using CalculoSeguroVeiculo.Test.MockDados;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace CalculoSeguroVeiculo.Test
{
    [TestFixture]
    public class VeiculoTest
    {
        private readonly ReplyContext _context;
        private readonly VeiculoRepository _veiculoRepository;
        private readonly VeiculoUnitOfWork _veiculoUnitOfWork;
        private readonly VeiculoApplicationService _veiculoApplicationService;
        private readonly Random _valorAleatorio;

        public VeiculoTest()
        {
            _context = new ReplyContext(new DbContextOptionsBuilder<ReplyContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _context.Veiculo.AddRange(VeiculoMock.Dados());
            _context.SaveChanges();
            _veiculoRepository = new VeiculoRepository(_context);
            _veiculoUnitOfWork = new VeiculoUnitOfWork(_context, _veiculoRepository);
            _veiculoApplicationService = new VeiculoApplicationService(_veiculoUnitOfWork);
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
            var resposta = _veiculoApplicationService.InclusaoVeiculo(veiculo);
            Assert.AreEqual(resposta.Status, StatusResposta.Sucesso);
            Assert.AreEqual(resposta.Exception, null);

            Assert.IsNotNull(veiculo.Marca);
            Assert.IsNotNull(veiculo.Modelo);
            Assert.IsTrue(veiculo.Valor > 0);
        }

        [Test]
        public void InclusaoSeguroFail()
        {
            var resposta = _veiculoApplicationService.InclusaoVeiculo(null);
            Assert.AreEqual(resposta.Status, StatusResposta.Erro);
            Assert.IsNotNull(resposta.Exception);
        }

        [Test]
        public void GetAllDtoPass()
        {
            var resposta = _veiculoApplicationService.GetAllDto();
            Assert.IsNotNull(resposta);
            Assert.IsNotNull(resposta.Resultado);
            foreach (var veiculo in resposta.Resultado)
            {
                Assert.IsNotNull(veiculo);
                Assert.IsNotNull(veiculo.Id);
                Assert.IsNotNull(veiculo.Marca);
                Assert.IsNotNull(veiculo.Modelo);
                Assert.IsNotNull(veiculo.Valor);
            }
        }

        [Test]
        public void GetByIdDtoPass()
        {
            var resposta = _veiculoApplicationService.GetByIdDto(1);
            Assert.IsNotNull(resposta);
            Assert.IsNotNull(resposta.Resultado);
            Assert.IsNotNull(resposta.Resultado.Id);
            Assert.IsNotNull(resposta.Resultado.Marca);
            Assert.IsNotNull(resposta.Resultado.Modelo);
            Assert.IsNotNull(resposta.Resultado.Valor);
        }

        [Test]
        public void GetByIdFail()
        {
            var resposta = _veiculoApplicationService.GetByIdDto(0);
            Assert.IsNotNull(resposta);
            Assert.AreEqual(resposta.Status, StatusResposta.Erro);
            Assert.IsNotNull(resposta.Exception);
        }
    }
}
