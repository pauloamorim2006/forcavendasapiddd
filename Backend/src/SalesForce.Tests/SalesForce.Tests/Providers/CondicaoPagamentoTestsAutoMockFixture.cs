using Bogus;
using Bogus.DataSets;
using ERP.Application.Services;
using ERP.Domain.Models;
using ERP.Domain.Repositories;
using ERP.Infra.Repository;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ERP.Domain.Tests.Providers
{
    [CollectionDefinition(nameof(CondicaoPagamentoAutoMockerCollection))]
    public class CondicaoPagamentoAutoMockerCollection : ICollectionFixture<CondicaoPagamentoTestsAutoMockerFixture>
    {
    }

    public class CondicaoPagamentoTestsAutoMockerFixture : IDisposable
    {
        public CondicaoPagamentoService CondicaoPagamentoService;
        public CondicaoPagamentoRepository CondicaoPagamentoRepository;
        public AutoMocker Mocker;

        public CondicaoPagamento GerarRegistroValido()
        {
            return GerarList(1, true).FirstOrDefault();
        }

        public IEnumerable<ERP.Domain.Models.CondicaoPagamento> ObterVariados()
        {
            var list = new List<CondicaoPagamento>();

            list.AddRange(GerarList(50, true).ToList());
            list.AddRange(GerarList(50, false).ToList());

            return list;
        }

        public IEnumerable<ERP.Domain.Models.CondicaoPagamento> GerarList(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var list = new Faker<CondicaoPagamento>("pt_BR")
                .CustomInstantiator(f => new CondicaoPagamento
                (
                    Guid.NewGuid(),
                    f.Name.FullName(genero),
                    f.Name.FullName(genero)
                )); ;

            return list.Generate(quantidade);
        }

        public ERP.Domain.Models.CondicaoPagamento GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var objeto = new Faker<CondicaoPagamento>("pt_BR")
                .CustomInstantiator(f => new CondicaoPagamento
                (
                    Guid.NewGuid(),
                    string.Empty,
                    string.Empty
                ));

            return objeto;
        }

        public CondicaoPagamentoService ObterService()
        {
            Mocker = new AutoMocker();
            CondicaoPagamentoService = Mocker.CreateInstance<CondicaoPagamentoService>();

            return CondicaoPagamentoService;
        }

        public ICondicaoPagamentoRepository ObterRepository()
        {
            Mocker = new AutoMocker();
            CondicaoPagamentoRepository = Mocker.CreateInstance<CondicaoPagamentoRepository>();

            return CondicaoPagamentoRepository;
        }

        public void Dispose()
        {
        }
    }
}
