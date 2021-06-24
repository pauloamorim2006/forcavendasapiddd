using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Domain.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 60)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.CnpjCpfDi)
                .NotEmpty().WithMessage("O campo CNPJ/CPF/DI precisa ser fornecido");

            RuleFor(f => f.Endereco.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 60)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Endereco.Numero)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 60)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Endereco.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 60)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Endereco.CidadeId)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.TipoPessoa)
                .NotEmpty().WithMessage("O campo Tipo de Pessoa precisa ser fornecido");

            RuleFor(f => f.TipoInscricaoEstadual)
                .NotEmpty().WithMessage("O campo Tipo de I.E. precisa ser fornecido");

        }
    }
}
