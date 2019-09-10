using FluentValidation;
using IFAvaliacao.Domain.Entities;
using System;

namespace IFAvaliacao.Domain.Validation
{
    public class VacaValidation : AbstractValidator<Vaca>
    {
        public VacaValidation()
        {
            RuleFor(x => x.FazendaId)
                .NotEmpty().WithMessage("Fazenda é obrigatorio.");

            RuleFor(x => x.Nome)
              .NotEmpty().WithMessage("Nome é obrigatorio.");

            RuleFor(x => x.Numero)
              .NotEmpty().WithMessage("Numero é obrigatorio.");
            
        }
    }
}
