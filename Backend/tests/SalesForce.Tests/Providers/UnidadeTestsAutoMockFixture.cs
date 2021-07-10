using Bogus;
using Bogus.DataSets;
using SalesForce.Application.Services;
using SalesForce.Domain.Models;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SalesForce.Domain.Tests.Providers
{
    [CollectionDefinition(nameof(UnidadeAutoMockerCollection))]
    public class UnidadeAutoMockerCollection : ICollectionFixture<UnidadeTestsAutoMockerFixture>
    {
    }

    public class UnidadeTestsAutoMockerFixture : IDisposable
    {
        public UnidadeService UnidadeService;
        public AutoMocker Mocker;

        public Models.Unidade GerarRegistroValido()
        {
            return GerarRegistroValido(1, true).FirstOrDefault();
        }

        public IEnumerable<Models.Unidade> ObterVariados()
        {
            var lista = new List<Models.Unidade>();

            lista.AddRange(GerarRegistroValido(50, true).ToList());
            lista.AddRange(GerarRegistroValido(50, false).ToList());

            return lista;
        }

        public IEnumerable<Models.Unidade> GerarRegistroValido(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var registros = new Faker<Unidade>("pt_BR")
                .CustomInstantiator(f => new Unidade
                (
                    Guid.NewGuid(),
                    f.Name.FullName(genero),
                    f.Name.FullName(genero).Substring(0, 2)
                )) ;

            return registros.Generate(quantidade);
        }

        public Models.Unidade GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var registro = new Faker<Unidade>("pt_BR")
                .CustomInstantiator(f => new Unidade(
                    Guid.Empty,
                    string.Empty,
                    string.Empty
                ));

            return registro;
        }

        public UnidadeService ObterService()
        {
            Mocker = new AutoMocker();
            UnidadeService = Mocker.CreateInstance<UnidadeService>();

            return UnidadeService;
        }
        public void Dispose()
        {
        }
    }
}
