using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using IFAvaliacao.Domain.Entities;

namespace IFAvaliacao.Domain.Validation
{
    public class FazendaValidation : AbstractValidator<Fazenda>
    {
        public FazendaValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome do Proprietario é obrigatorio.");

            RuleFor(x => x.NomeFazenda)
                .NotEmpty()
                .WithMessage("Nome da fazenda é obrigatorio.");

            RuleFor(x => x.Endereco)
                .NotEmpty()
                .WithMessage("Endereço é obrigatorio.");

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .WithMessage("Cidade é obrigatorio.");

            RuleFor(x => x.Estado)
                .NotEmpty()
                .WithMessage("Estado é obrigatorio.");
        }
    }
}
