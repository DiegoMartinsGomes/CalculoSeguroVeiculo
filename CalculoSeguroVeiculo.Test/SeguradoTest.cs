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
        public void AddPass()
        {
            var segurado = new Segurado()
            {
                Nome = $"Nome{_valorAleatorio.Next()}",
                CPF = $"{12345678910 * _valorAleatorio.Next()}".Substring(0, 11),
                Idade = _valorAleatorio.Next(18, 100)
            };

            _seguradoApplicationService.Add(segurado);

            Assert.IsNotNull(segurado.Nome);
            Assert.IsNotNull(segurado.CPF);
            Assert.IsTrue(segurado.Idade > 0);
        }

        [Test]
        public void AddFail()
        {
            var segurado = new Segurado();
            _seguradoApplicationService.Add(segurado);

            Assert.IsNull(segurado.Nome);
            Assert.IsNull(segurado.CPF);
            Assert.IsFalse(segurado.Idade > 0);
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
    }
}
