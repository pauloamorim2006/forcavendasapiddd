using Bogus;
using Bogus.DataSets;
using ERP.Application.Services;
using ERP.Domain.Models;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ERP.Domain.Tests.Providers
{
    [CollectionDefinition(nameof(FormaPagamentoAutoMockerCollection))]
    public class FormaPagamentoAutoMockerCollection : ICollectionFixture<FormaPagamentoTestsAutoMockerFixture>
    {
    }

    public class FormaPagamentoTestsAutoMockerFixture : IDisposable
    {
        public FormaPagamentoService FormaPagamentoService;
        public AutoMocker Mocker;

        public Models.FormaPagamento GerarRegistroValido()
        {
            return GerarList(1, true).FirstOrDefault();
        }

        public IEnumerable<ERP.Domain.Models.FormaPagamento> ObterVariados()
        {
            var list = new List<ERP.Domain.Models.FormaPagamento>();

            list.AddRange(GerarList(50, true).ToList());
            list.AddRange(GerarList(50, false).ToList());

            return list;
        }

        public IEnumerable<FormaPagamento> GerarList(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var list = new Faker<FormaPagamento>("pt_BR")
                .CustomInstantiator(f => new FormaPagamento
                (
                    Guid.NewGuid(),
                    f.Name.FullName(genero),
                    true,
                    "D",
                    true,
                    true,
                    true,
                    "01"
                ));

            return list.Generate(quantidade);
        }

        public Models.FormaPagamento GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var objeto = new Faker<Models.FormaPagamento>("pt_BR")
                .CustomInstantiator(f => new Models.FormaPagamento(
                    Guid.Empty,
                    string.Empty,
                    false,
                    string.Empty,
                    false,
                    false,
                    false,
                    string.Empty
                ));

            return objeto;
        }

        public FormaPagamentoService ObterService()
        {
            Mocker = new AutoMocker();
            FormaPagamentoService = Mocker.CreateInstance<FormaPagamentoService>();

            return FormaPagamentoService;
        }

        public void Dispose()
        {
        }
    }
}
