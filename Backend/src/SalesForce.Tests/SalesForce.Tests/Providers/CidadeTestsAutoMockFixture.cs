using Bogus;
using Bogus.DataSets;
using ERP.Application.Services;
using ERP.Domain.Models;
using ERP.Domain.Services;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ERP.Domain.Tests.Providers
{
    [CollectionDefinition(nameof(CidadeAutoMockerCollection))]
    public class CidadeAutoMockerCollection : ICollectionFixture<CidadeTestsAutoMockerFixture>
    {
    }

    public class CidadeTestsAutoMockerFixture : IDisposable
    {
        public CidadeService CidadeService;
        public AutoMocker Mocker;

        public ERP.Domain.Models.Cidade GerarRegistroValido()
        {
            return GerarList(1, true).FirstOrDefault();
        }

        public IEnumerable<ERP.Domain.Models.Cidade> ObterVariados()
        {
            var list = new List<ERP.Domain.Models.Cidade>();

            list.AddRange(GerarList(50, true).ToList());
            list.AddRange(GerarList(50, false).ToList());

            return list;
        }

        public IEnumerable<ERP.Domain.Models.Cidade> GerarList(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var list = new Faker<ERP.Domain.Models.Cidade>("pt_BR")
                .CustomInstantiator(f => new Cidade
                (
                    Guid.Empty,
                    f.Random.Number(),
                    f.Address.City(),
                    "MG"
                ));

            return list.Generate(quantidade);
        }

        public ERP.Domain.Models.Cidade GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var objeto = new Faker<ERP.Domain.Models.Cidade>("pt_BR")
                .CustomInstantiator(f => new ERP.Domain.Models.Cidade
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
