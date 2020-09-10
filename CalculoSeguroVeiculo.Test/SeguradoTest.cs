using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
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
    public class SeguradoTest
    {
        private readonly ReplyContext _context;
        private readonly SeguradoRepository _seguradoRepository;
        private readonly SeguradoUnitOfWork _seguradoUnitOfWork;
        private readonly SeguradoApplicationService _seguradoApplicationService;
        private readonly Random _valorAleatorio;

        public SeguradoTest()
        {
            _context = new ReplyContext(new DbContextOptionsBuilder<ReplyContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _context.Segurado.AddRange(SeguradoMock.Dados());
            _context.SaveChanges();

            _seguradoRepository = new SeguradoRepository(_context);
            _seguradoUnitOfWork = new SeguradoUnitOfWork(_context, _seguradoRepository);
            _seguradoApplicationService = new SeguradoApplicationService(_seguradoUnitOfWork);
            _valorAleatorio = new Random();
        }

        [Test]
        public void InclusaoSeguradoPass()
        {
            var segurado = new SeguradoPostDto()
            {
                Nome = $"Nome{_valorAleatorio.Next()}",
                CPF = $"{12345678910 * _valorAleatorio.Next()}".Substring(0, 11),
                Idade = _valorAleatorio.Next(18, 100)
            };

            _seguradoApplicationService.InclusaoSegurado(segurado);

            Assert.IsNotNull(segurado.Nome);
            Assert.IsNotNull(segurado.CPF);
            Assert.IsTrue(segurado.Idade > 0);
        }

        [Test]
        public void InclusaoSeguradoFail()
        {
            try
            {
                _seguradoApplicationService.InclusaoSegurado(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Não foi possível Inserir o Segurado", e.Message);
            }
        }

        [Test]
        public void GetAllDtoIsNotNull()
        {
            var segurados = _seguradoApplicationService.GetAllDto();
            foreach (var segurado in segurados)
            {
                Assert.IsNotNull(segurado);
                Assert.IsNotNull(segurado.Id);
                Assert.IsNotNull(segurado.Nome);
                Assert.IsNotNull(segurado.CPF);
                Assert.IsNotNull(segurado.Idade);
            }
        }

        [Test]
        public void GetByIdDtoNotNull()
        {
            var segurado = _seguradoApplicationService.GetByIdDto(1);
            Assert.IsNotNull(segurado);
            Assert.IsNotNull(segurado.Id);
            Assert.IsNotNull(segurado.Nome);
            Assert.IsNotNull(segurado.CPF);
            Assert.IsNotNull(segurado.Idade);
        }

        [Test]
        public void GetByIdDtoNull()
        {
            try
            {
                var segurado = _seguradoApplicationService.GetByIdDto(0);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Não foi possível localizar o Segurado", e.Message);
            }
        }
    }
}
