using CalculoSeguroVeiculo.Crosscutting.Enums;
using CalculoSeguroVeiculo.DataTransferObject.SeguroDto;
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
    public class SeguroTest
    {
        private readonly ReplyContext _context;
        private readonly SeguroRepository _seguroRepository;
        private readonly SeguroUnitOfWork _seguroUnitOfWork;
        private readonly SeguradoRepository _seguradoRepository;
        private readonly VeiculoRepository _veiculoRepository;
        private readonly SeguroApplicationService _seguroApplicationService;

        public SeguroTest()
        {
            _context = new ReplyContext(new DbContextOptionsBuilder<ReplyContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _context.Seguro.AddRange(SeguroMock.Dados(SeguradoMock.Dados(), VeiculoMock.Dados()));
            _context.SaveChanges();
            _seguroRepository = new SeguroRepository(_context);
            _seguradoRepository = new SeguradoRepository(_context);
            _veiculoRepository = new VeiculoRepository(_context);
            _seguroUnitOfWork = new SeguroUnitOfWork(_context, _seguroRepository, _seguradoRepository, _veiculoRepository);
            _seguroApplicationService = new SeguroApplicationService(_seguroUnitOfWork);
        }

        [Test]
        public void InclusaoSeguroPass()
        {
            var seguro = new SeguroPostDto()
            {
                IdSegurado = 1,
                IdVeiculo = 10,
            };
            _seguroApplicationService.InclusaoSeguro(seguro);
            Assert.IsNotNull(seguro);
            Assert.IsTrue(seguro.IdSegurado > 0);
            Assert.IsTrue(seguro.IdVeiculo > 0);
        }

        [Test]
        public void InclusaoSeguroFail()
        {
            var resposta = _seguroApplicationService.InclusaoSeguro(null);
            Assert.AreEqual(resposta.Status, StatusResposta.Erro);
        }

        [Test]
        public void RelatorioV1IsNotNull()
        {
            var resposta = _seguroApplicationService.GerarRelatorioV1();
            Assert.IsNotNull(resposta);
            Assert.IsNotNull(resposta.Resultado.Media);
            Assert.IsTrue(resposta.Resultado.Media > 0);
        }

        [Test]
        public void RelatorioV2IsNotNull()
        {
            var resposta = _seguroApplicationService.GerarRelatorioV2();
            Assert.IsNotNull(resposta);
            Assert.IsNotNull(resposta.Resultado.Seguros);
            Assert.IsNotNull(resposta.Resultado.Mensagem);
            Assert.IsTrue(resposta.Resultado.Mensagem.Contains("A média aritimética dos Seguros é de:"));
            Assert.IsNotNull(resposta.Resultado.Media);
            Assert.IsTrue(resposta.Resultado.Media > 0);
        }

        [Test]
        public void GetAllDtoIsNotNull()
        {
            var resposta = _seguroApplicationService.GetAllDto();
            Assert.IsNotNull(resposta);
            foreach (var seguro in resposta.Resultado)
            {
                Assert.IsNotNull(seguro);
                Assert.IsNotNull(seguro.Id);
                Assert.IsNotNull(seguro.IdSegurado);
                Assert.IsNotNull(seguro.IdVeiculo);
                Assert.IsNotNull(seguro.DataCalculo);
                Assert.IsNotNull(seguro.Valor);
                Assert.IsNotNull(seguro.Segurado);
                Assert.IsNotNull(seguro.Segurado.Id);
                Assert.IsNotNull(seguro.Segurado.Nome);
                Assert.IsNotNull(seguro.Segurado.CPF);
                Assert.IsNotNull(seguro.Segurado.Idade);
                Assert.IsNotNull(seguro.Veiculo);
                Assert.IsNotNull(seguro.Veiculo.Id);
                Assert.IsNotNull(seguro.Veiculo.Marca);
                Assert.IsNotNull(seguro.Veiculo.Modelo);
                Assert.IsNotNull(seguro.Veiculo.Valor);
            }
        }

        [Test]
        public void GetByIdDtoIsNotNull()
        {
            var resposta = _seguroApplicationService.GetByIdDto(1);
            Assert.IsNotNull(resposta.Resultado);
            Assert.IsNotNull(resposta.Resultado.Segurado);
            Assert.IsNotNull(resposta.Resultado.Veiculo);
        }

        [Test]
        public void GetByIdDtoIsNull()
        {
            var resposta = _seguroApplicationService.GetByIdDto(0);
            Assert.AreEqual(resposta.Status, StatusResposta.Erro);
        }
    }
}
