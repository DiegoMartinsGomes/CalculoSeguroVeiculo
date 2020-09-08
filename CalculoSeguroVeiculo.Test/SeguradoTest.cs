using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
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
using CalculoSeguroVeiculo.Domain.Mappings;

namespace CalculoSeguroVeiculo.Test
{
    [TestFixture]
    public class SeguradoTest
    {
        private readonly ReplyContext _context;
        private readonly SeguradoRepository _seguradoRepository;
        private readonly SeguradoApplicationService _seguradoApplicationService;
        private readonly Random _valorAleatorio;

        public SeguradoTest()
        {
            _context = new ReplyContext(new DbContextOptionsBuilder<ReplyContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _context.Segurado.AddRange(SeguradoMock.Dados());
            _context.SaveChanges();

            _seguradoRepository = new SeguradoRepository(_context);
            _seguradoApplicationService = new SeguradoApplicationService(_seguradoRepository);
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
        public void TestGetIdNotNull()
        {
            var id = 1;
            var veiculo = _seguradoApplicationService.GetById(id);
            Assert.NotNull(veiculo);
            Assert.NotNull(veiculo.Id = id);
        }

        [Test]
        public void TestGetIdIsNull()
        {
            var id = 0;
            var segurado = _seguradoApplicationService.GetById(id);
            Assert.IsNull(segurado);
        }

        [Test]
        public void TestGetAllNotNull()
        {
            var segurados = _seguradoApplicationService.GetAll();
            Assert.NotNull(segurados);
        }

        [Test]
        public void TestGetAllIsNull()
        {
            int id = 0;
            var segurados = _seguradoApplicationService.GetAll().Where(x => x.Id == id);
            Assert.IsEmpty(segurados);
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
