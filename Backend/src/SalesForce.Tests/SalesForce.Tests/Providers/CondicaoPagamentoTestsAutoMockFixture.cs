using Bogus;
using Bogus.DataSets;
using ERP.Domain.Repositories;
using ERP.Domain.Services;
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

        public ERP.Domain.Models.CondicaoPagamento GerarRegistroValido()
        {
            return GerarList(1, true).FirstOrDefault();
        }

        public IEnumerable<ERP.Domain.Models.CondicaoPagamento> ObterVariados()
        {
            var list = new List<ERP.Domain.Models.CondicaoPagamento>();

            list.AddRange(GerarList(50, true).ToList());
            list.AddRange(GerarList(50, false).ToList());

            return list;
        }

        public IEnumerable<ERP.Domain.Models.CondicaoPagamento> GerarList(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var list = new Faker<ERP.Domain.Models.CondicaoPagamento>("pt_BR")
                .CustomInstantiator(f => new ERP.Domain.Models.CondicaoPagamento
                {
                    Nome = f.Name.FullName(genero),
                    Descricao = f.Name.FullName(genero)
                });

            return list.Generate(quantidade);
        }

        public ERP.Domain.Models.CondicaoPagamento GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var objeto = new Faker<ERP.Domain.Models.CondicaoPagamento>("pt_BR")
                .CustomInstantiator(f => new ERP.Domain.Models.CondicaoPagamento
                {
                    Nome = string.Empty,
                    Descricao = string.Empty
                });

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
