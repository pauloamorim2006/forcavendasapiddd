using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using SalesForce.Application.Services;
using SalesForce.Domain.Models;
using SalesForce.Domain.Services;
using Moq.AutoMock;
using SalesForce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SalesForce.Domain.Tests.Providers
{
    [CollectionDefinition(nameof(ClienteAutoMockerCollection))]
    public class ClienteAutoMockerCollection : ICollectionFixture<ClienteTestsAutoMockerFixture>
    {
    }

    public class ClienteTestsAutoMockerFixture : IDisposable
    {
        public ClienteService ClienteService;
        public AutoMocker Mocker;

        public SalesForce.Domain.Models.Cliente GerarClienteValido()
        {
            return GerarClientes(1, true).FirstOrDefault();
        }

        public IEnumerable<SalesForce.Domain.Models.Cliente> ObterClientesVariados()
        {
            var clientes = new List<SalesForce.Domain.Models.Cliente>();

            clientes.AddRange(GerarClientes(50, true).ToList());
            clientes.AddRange(GerarClientes(50, false).ToList());

            return clientes;
        }

        public IEnumerable<SalesForce.Domain.Models.Cliente> GerarClientes(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var clientes = new Faker<SalesForce.Domain.Models.Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente
                (
                    Guid.NewGuid(),
                    f.Name.FullName(genero),
                    f.Company.Cnpj(),                    
                    true,
                    "F",
                    f.Phone.PhoneNumber(),
                    f.Internet.Email(),
                    f.Company.Cnpj(),
                    9,
                    false,
                    new Endereco(
                        f.Address.StreetName(),
                        f.Random.Number(90000).ToString(),
                        f.Name.FullName(genero),
                        f.Address.ZipCode(),                    
                        f.Address.SecondaryAddress(),
                        Guid.NewGuid()
                    )
                ))
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.Nome.ToLower()));

            return clientes.Generate(quantidade);
        }

        public SalesForce.Domain.Models.Cliente GerarClienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<SalesForce.Domain.Models.Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente
                (
                    Guid.Empty,
                    string.Empty,
                    string.Empty,
                    false,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    0,
                    false,
                    new Endereco(
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        Guid.Empty
                    )
                ));

            return cliente;
        }

        public ClienteService ObterClienteService()
        {
            Mocker = new AutoMocker();
            ClienteService = Mocker.CreateInstance<ClienteService>();

            return ClienteService;
        }
        public void Dispose()
        {
        }
    }
}
