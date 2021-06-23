using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using ERP.Application.Services;
using ERP.Domain.Services;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ERP.Domain.Tests.Providers
{
    [CollectionDefinition(nameof(ClienteAutoMockerCollection))]
    public class ClienteAutoMockerCollection : ICollectionFixture<ClienteTestsAutoMockerFixture>
    {
    }

    public class ClienteTestsAutoMockerFixture : IDisposable
    {
        public ClienteService ClienteService;
        public AutoMocker Mocker;

        public ERP.Domain.Models.Cliente GerarClienteValido()
        {
            return GerarClientes(1, true).FirstOrDefault();
        }

        public IEnumerable<ERP.Domain.Models.Cliente> ObterClientesVariados()
        {
            var clientes = new List<ERP.Domain.Models.Cliente>();

            clientes.AddRange(GerarClientes(50, true).ToList());
            clientes.AddRange(GerarClientes(50, false).ToList());

            return clientes;
        }

        public IEnumerable<ERP.Domain.Models.Cliente> GerarClientes(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var clientes = new Faker<ERP.Domain.Models.Cliente>("pt_BR")
                .CustomInstantiator(f => new ERP.Domain.Models.Cliente
                {
                    Nome = f.Name.FullName(genero),
                    CnpjCpfDi = f.Company.Cnpj(),
                    Endereco = f.Address.StreetName(),
                    Numero = f.Random.Number(90000).ToString(),
                    Bairro = f.Name.FullName(genero),
                    Cep = f.Address.ZipCode(),
                    CidadeId = Guid.NewGuid(),
                    Ativo = true,
                    TipoPessoa = "F",
                    Telefone = f.Phone.PhoneNumber(),
                    Complemento = f.Address.SecondaryAddress(),
                    Email = f.Internet.Email(),
                    InscricaoEstadual = f.Company.Cnpj(),
                    TipoInscricaoEstadual = 9
                })
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.Nome.ToLower()));

            return clientes.Generate(quantidade);
        }

        public ERP.Domain.Models.Cliente GerarClienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<ERP.Domain.Models.Cliente>("pt_BR")
                .CustomInstantiator(f => new ERP.Domain.Models.Cliente
                {
                    Nome = string.Empty,
                    CnpjCpfDi = string.Empty,
                    Endereco = string.Empty,
                    Numero = string.Empty,
                    Bairro = string.Empty,
                    Cep = string.Empty,
                    CidadeId = Guid.NewGuid(),
                    Ativo = true,
                    TipoPessoa = "F",
                    Telefone = string.Empty,
                    Complemento = string.Empty,
                    Email = string.Empty,
                    InscricaoEstadual = string.Empty,
                    TipoInscricaoEstadual = 9
                });

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
