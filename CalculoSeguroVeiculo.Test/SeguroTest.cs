using CalculoSeguroVeiculo.Crosscutting.Dto.SeguroDto;
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
    public class SeguroTest
    {
        private readonly ReplyContext _context;
        private readonly SeguroRepository _seguroRepository;
        private readonly SeguradoRepository _seguradoRepository;
        private readonly VeiculoRepository _veiculoRepository;
        private readonly SeguroApplicationService _seguroApplicationService;
        private readonly SeguradoApplicationService _seguradoApplicationService;
        private readonly VeiculoApplicationService _veiculoApplicationService;
        private readonly Random _valorAleatorio;

        public SeguroTest()
        {
            _context = new ReplyContext(new DbContextOptionsBuilder<ReplyContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _context.Seguro.AddRange(SeguroMock.Dados(SeguradoMock.Dados(), VeiculoMock.Dados()));
            _context.SaveChanges();

            _seguroRepository = new SeguroRepository(_context);
            _seguradoRepository = new SeguradoRepository(_context);
            _veiculoRepository = new VeiculoRepository(_context);

            _seguradoApplicationService = new SeguradoApplicationService(_seguradoRepository);
            _veiculoApplicationService = new VeiculoApplicationService(_veiculoRepository);

            _seguroApplicationService = new SeguroApplicationService(_seguroRepository, _seguradoApplicationService, _veiculoApplicationService);
            _valorAleatorio = new Random();
        }

        [Test]
        public void AddPass()
        {
            var seguro = new SeguroPostDto()
            {
                IdSegurado = 1,
                IdVeiculo = 10,
            };

            _seguroApplicationService.InclusaoSeguro(seguro);

            Assert.IsTrue(seguro.IdSegurado > 0);
            Assert.IsTrue(seguro.IdVeiculo > 0);
        }

        [Test]
        public void AddFail()
        {
            var seguro = new Seguro();
            _seguroApplicationService.Add(seguro);

            Assert.IsFalse(seguro.IdSegurado > 0);
            Assert.IsFalse(seguro.IdVeiculo > 0);
        }

        [Test]
        public void TestGetIdNotNull()
        {
            var id = 1;
            var veiculo = _seguroApplicationService.GetById(id);

            Assert.NotNull(veiculo);
            Assert.NotNull(veiculo.Id = id);
        }

        [Test]
        public void TestGetIdIsNull()
        {
            var id = 0;
            var segurado = _seguroApplicationService.GetById(id);

            Assert.IsNull(segurado);
        }

        [Test]
        public void TestGetAllNotNull()
        {
            var segurados = _seguroApplicationService.GetAll();

            Assert.NotNull(segurados);
        }

        [Test]
        public void TestGetAllIsNull()
        {
            int id = 0;
            var segurados = _seguroApplicationService.GetAll().Where(x => x.Id == id);

            Assert.IsEmpty(segurados);
        }

        [Test]
        public void EntitiesToDtosIsNotNull()
        {
            var veiculos = _seguroApplicationService.EntitiesToDtos(new List<Seguro>());

            Assert.IsNotNull(veiculos);
        }

        [Test]
        public void EntityToDtoIsNotNull()
        {
            var segurado = _context.Segurado.Where(x => x.Id == 1).FirstOrDefault();
            var veiculo = _context.Veiculo.Where(x => x.Id == 10).FirstOrDefault();

            var seguro = new Seguro()
            {
                Id = _valorAleatorio.Next(),
                IdSegurado = segurado.Id,
                IdVeiculo = veiculo.Id,
                DataCalculo = DateTime.Now,
                Segurado = segurado,
                Veiculo = veiculo,
                Valor = Convert.ToDecimal(_valorAleatorio.NextDouble())
            };

            var seguroDto = _seguroApplicationService.EntityToDto(seguro);

            Assert.IsNotNull(seguroDto);
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
    }
}
