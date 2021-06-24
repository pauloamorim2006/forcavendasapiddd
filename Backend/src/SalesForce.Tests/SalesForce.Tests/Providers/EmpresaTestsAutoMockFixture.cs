using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using ERP.Application.Services;
using ERP.Domain.Models;
using Moq.AutoMock;
using SalesForce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ERP.Domain.Tests.Providers
{
    [CollectionDefinition(nameof(EmpresaAutoMockerCollection))]
    public class EmpresaAutoMockerCollection : ICollectionFixture<EmpresaTestsAutoMockerFixture>
    {
    }

    public class EmpresaTestsAutoMockerFixture : IDisposable
    {
        public EmpresaService EmpresaService;
        public AutoMocker Mocker;

        public ERP.Domain.Models.Empresa GerarRegistroValido()
        {
            return GerarList(1, true).FirstOrDefault();
        }

        public IEnumerable<ERP.Domain.Models.Empresa> ObterVariados()
        {
            var list = new List<ERP.Domain.Models.Empresa>();

            list.AddRange(GerarList(50, true).ToList());
            list.AddRange(GerarList(50, false).ToList());

            return list;
        }

        public IEnumerable<ERP.Domain.Models.Empresa> GerarList(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var list = new Faker<Empresa>("pt_BR")
                .CustomInstantiator(f => new Empresa
                (
                    Guid.NewGuid(),
                    f.Name.FullName(genero),
                    f.Name.FullName(genero),
                    f.Company.Cnpj(),
                    "F",
                    f.Phone.PhoneNumber(),
                    f.Internet.Email(),
                    f.Company.Cnpj(),
                    9,
                    1,
                    new Endereco(
                        f.Address.StreetName(),
                        f.Random.Number(90000).ToString(),
                        f.Name.FullName(genero),
                        f.Address.ZipCode(),
                        f.Address.SecondaryAddress(),
                        Guid.NewGuid()
                    )
                )) ;

            return list.Generate(quantidade);
        }

        public ERP.Domain.Models.Empresa GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var objeto = new Faker<Empresa>("pt_BR")
                .CustomInstantiator(f => new Empresa
                    (
                        Guid.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        0,
                        1,
                        new Endereco(
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            Guid.Empty                 
                    )
            ));

            return objeto;
        }

        public EmpresaService ObterService()
        {
            Mocker = new AutoMocker();
            EmpresaService = Mocker.CreateInstance<EmpresaService>();

            return EmpresaService;
        }
        public void Dispose()
        {
        }
    }
}
