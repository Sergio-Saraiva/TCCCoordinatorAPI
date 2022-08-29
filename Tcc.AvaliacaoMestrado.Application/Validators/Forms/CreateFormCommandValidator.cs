using FluentValidation;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms;

namespace Tcc.AvaliacaoMestrado.Application.Validators.Forms
{
    public class CreateFormCommandValidator : AbstractValidator<CreateFormCommand>
    {
        public CreateFormCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null")
                .MaximumLength(200).WithMessage("{PropertyName} must have less than 200 characters")
                .MinimumLength(3).WithMessage("{PropertyName} must have more than 3 characters");
        }
    }
}
