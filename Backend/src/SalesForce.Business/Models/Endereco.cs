using SalesForce.Domain.Models;
using SalesForce.Core.DomainObjects;
using System;

namespace SalesForce.Domain.Models
{
    public class Endereco : ValueObject
    {
        protected Endereco()
        {
        }

        public Endereco(string logradouro, string numero, string bairro, string cep, string complemento, Guid cidadeId)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
            Complemento = complemento;
            CidadeId = cidadeId;
        }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Complemento { get; private set; }
        public Guid CidadeId { get; private set; }
        public Cidade Cidade { get; private set; }
    }
}
