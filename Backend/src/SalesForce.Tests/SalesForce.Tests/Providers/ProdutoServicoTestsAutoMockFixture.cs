using Bogus;
using Bogus.DataSets;
using ERP.Application.Services;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ERP.Domain.Tests.Providers
{
    [CollectionDefinition(nameof(ProdutoServicoAutoMockerCollection))]
    public class ProdutoServicoAutoMockerCollection : ICollectionFixture<ProdutoServicoTestsAutoMockerFixture>
    {
    }

    public class ProdutoServicoTestsAutoMockerFixture : IDisposable
    {
        public ProdutoServicoService ProdutoServicoService;
        public AutoMocker Mocker;

        public Models.ProdutoServico GerarRegistroValido()
        {
            return GerarList(1, true).FirstOrDefault();
        }

        public IEnumerable<ERP.Domain.Models.ProdutoServico> ObterVariados()
        {
            var list = new List<ERP.Domain.Models.ProdutoServico>();

            list.AddRange(GerarList(50, true).ToList());
            list.AddRange(GerarList(50, false).ToList());

            return list;
        }

        public IEnumerable<Models.ProdutoServico> GerarList(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var list = new Faker<Models.ProdutoServico>("pt_BR")
                .CustomInstantiator(f => new Models.ProdutoServico
                (
                    Guid.NewGuid(),
                    f.Name.FullName(genero),
                    f.Random.Double(0, 99999),
                    f.Random.Double(0, 99999),
                    Guid.NewGuid(),
                    true,
                    true,                    
                    f.Random.Int(0, 999999).ToString()                    
                ));

            return list.Generate(quantidade);
        }

        public Models.ProdutoServico GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var objeto = new Faker<Models.ProdutoServico>("pt_BR")
                .CustomInstantiator(f => new Models.ProdutoServico
                (
                    Guid.Empty,
                    string.Empty,
                    0,
                    0,
                    Guid.Empty,
                    false,
                    false,
                    string.Empty
                ));

            return objeto;
        }

        public ProdutoServicoService ObterService()
        {
            Mocker = new AutoMocker();
            ProdutoServicoService = Mocker.CreateInstance<ProdutoServicoService>();

            return ProdutoServicoService;
        }

        public void Dispose()
        {
        }
    }
}
