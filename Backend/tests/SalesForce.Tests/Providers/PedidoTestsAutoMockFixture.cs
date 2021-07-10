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
    [CollectionDefinition(nameof(PedidoAutoMockerCollection))]
    public class PedidoAutoMockerCollection : ICollectionFixture<PedidoTestsAutoMockerFixture>
    {
    }

    public class PedidoTestsAutoMockerFixture : IDisposable
    {
        public PedidoService PedidoService;
        public AutoMocker Mocker;

        public Models.Pedido GerarRegistroValido()
        {
            return GerarList(1, true).FirstOrDefault();
        }

        public IEnumerable<Pedido> ObterVariados()
        {
            var list = new List<Pedido>();

            list.AddRange(GerarList(50, true).ToList());
            list.AddRange(GerarList(50, false).ToList());

            return list;
        }

        public IEnumerable<Models.Pedido> GerarList(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var list = new Faker<Pedido>("pt_BR")
                .CustomInstantiator(f => Pedido.PedidoFactory.Novo
                (
                    Guid.NewGuid(),
                    f.Random.Number(),
                    StatusPedido.Aberto,
                    Guid.NewGuid(),
                    DateTime.Now,
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    new List<PedidoItem>
                        {
                            new PedidoItem
                            (
                                Guid.NewGuid(),
                                Guid.NewGuid(),
                                f.Random.Number(),
                                Guid.NewGuid(),
                                f.Random.Number(1, 10000),
                                f.Random.Number(1, 10000),
                                f.Random.Number(1, 10000),
                                f.Random.Number(1, 10000),
                                10
                            )
                        }
                ));

            return list.Generate(quantidade);
        }

        public Models.Pedido GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var objeto = new Faker<Models.Pedido>("pt_BR")
                .CustomInstantiator(f => new Pedido
                (
                    Guid.Empty,
                    0,
                    StatusPedido.Aberto,
                    Guid.Empty,
                    DateTime.Now,
                    Guid.Empty,
                    Guid.Empty
                ));

            return objeto;
        }

        public PedidoService ObterService()
        {
            Mocker = new AutoMocker();
            PedidoService = Mocker.CreateInstance<PedidoService>();

            return PedidoService;
        }
        
        public void Dispose()
        {
        }
    }
}
