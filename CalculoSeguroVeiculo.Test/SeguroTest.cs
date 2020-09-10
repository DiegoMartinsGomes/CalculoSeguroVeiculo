using CalculoSeguroVeiculo.DataTransferObject.SeguroDto;
using CalculoSeguroVeiculo.Infrastructure.Context;
using CalculoSeguroVeiculo.Infrastructure.Repository;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork;
using CalculoSeguroVeiculo.Service.Services;
using CalculoSeguroVeiculo.Test.MockDados;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

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
            try
            {
                _seguroApplicationService.InclusaoSeguro(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Não foi possível Inserir o Seguro.", e.Message);
            }
        }

        [Test]
        public void CalculoSeguroVeiculoIsNotNull()
        {
            var veiculo = _context.Veiculo.Where(x => x.Id == 1).FirstOrDefault();
            var valorSeguro = _seguroApplicationService.CalculoSeguroVeiculo(veiculo);

            Assert.IsNotNull(valorSeguro);
            Assert.IsTrue(valorSeguro > 0);
        }

        [Test]
        public void CalculoSeguroVeiculoIsNull()
        {
            try
            {
                _seguroApplicationService.CalculoSeguroVeiculo(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Não foi possível Calcular o Seguro.", e.Message);
            }
        }

        [Test]
        public void RelatorioV1IsNotNull()
        {
            var relatorio = _seguroApplicationService.GerarRelatorioV1();

            Assert.IsNotNull(relatorio);
            Assert.IsNotNull(relatorio.Media);
            Assert.IsTrue(relatorio.Media > 0);
        }

        [Test]
        public void RelatorioV2IsNotNull()
        {
            var relatorio = _seguroApplicationService.GerarRelatorioV2();

            Assert.IsNotNull(relatorio);
            Assert.IsNotNull(relatorio.Seguros);
            Assert.IsNotNull(relatorio.Mensagem);
            Assert.IsTrue(relatorio.Mensagem.Contains("A média aritimética dos Seguros é de:"));
            Assert.IsNotNull(relatorio.Media);
            Assert.IsTrue(relatorio.Media > 0);
        }

        [Test]
        public void GetAllDtoIsNotNull()
        {
            var seguros = _seguroApplicationService.GetAllDto();

            Assert.IsNotNull(seguros);

            foreach (var seguro in seguros)
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
            var seguro = _seguroApplicationService.GetByIdDto(1);

            Assert.IsNotNull(seguro);
            Assert.IsNotNull(seguro.Segurado);
            Assert.IsNotNull(seguro.Veiculo);
        }

        [Test]
        public void GetByIdDtoIsNull()
        {
            try
            {
                _seguroApplicationService.GetByIdDto(0);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Não foi possível localizar o Seguro.", e.Message);
            }
        }

        [Test]
        public void GetAllRelacionadoIsNotNull()
        {
            var seguros = _seguroApplicationService.GetAllRelacionado();

            Assert.IsNotNull(seguros);

            foreach (var seguro in seguros)
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
    }
}
