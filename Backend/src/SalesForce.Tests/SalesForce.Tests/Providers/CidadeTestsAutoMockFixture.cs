using Bogus;
using Bogus.DataSets;
using SalesForce.Application.Services;
using SalesForce.Domain.Models;
using SalesForce.Domain.Services;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SalesForce.Domain.Tests.Providers
{
    [CollectionDefinition(nameof(CidadeAutoMockerCollection))]
    public class CidadeAutoMockerCollection : ICollectionFixture<CidadeTestsAutoMockerFixture>
    {
    }

    public class CidadeTestsAutoMockerFixture : IDisposable
    {
        public CidadeService CidadeService;
        public AutoMocker Mocker;

        public SalesForce.Domain.Models.Cidade GerarRegistroValido()
        {
            return GerarList(1, true).FirstOrDefault();
        }

        public IEnumerable<SalesForce.Domain.Models.Cidade> ObterVariados()
        {
            var list = new List<SalesForce.Domain.Models.Cidade>();

            list.AddRange(GerarList(50, true).ToList());
            list.AddRange(GerarList(50, false).ToList());

            return list;
        }

        public IEnumerable<SalesForce.Domain.Models.Cidade> GerarList(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var list = new Faker<SalesForce.Domain.Models.Cidade>("pt_BR")
                .CustomInstantiator(f => new Cidade
                (
                    Guid.Empty,
                    f.Random.Number(),
                    f.Address.City(),
                    "MG"
                ));

            return list.Generate(quantidade);
        }

        public SalesForce.Domain.Models.Cidade GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var objeto = new Faker<SalesForce.Domain.Models.Cidade>("pt_BR")
                .CustomInstantiator(f => new SalesForce.Domain.Models.Cidade
                (
                    Guid.Empty,
                    f.Random.Number(),
                    string.Empty,
                    string.Empty
                ));

            return objeto;
        }

        public CidadeService ObterService()
        {
            Mocker = new AutoMocker();
            CidadeService = Mocker.CreateInstance<CidadeService>();

            return CidadeService;
        }
        public void Dispose()
        {
        }
    }
}
